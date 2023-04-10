#Requires -Version 7.3

<#
.SYNOPSIS
Removes C# comments from one or multiple files.

.DESCRIPTION
The Remove-CsComments function removes C# comments from one or multiple files. By default, both single-line and multi-line comments are removed, but you can choose to enable or disable either or both.

.PARAMETER DirectoryPath
Specifies the path(s) to the file(s) to be processed.

.PARAMETER SinglelineEnabled
Indicates whether to remove single-line comments.

.PARAMETER MultilineEnabled
Indicates whether to remove multi-line comments.

.EXAMPLE
Remove-CsComments DirectoryPath "."

This example removes both single-line and multi-line comments from the specified file.

.EXAMPLE
Remove-CsCommentsFromFiles -FilePaths "." -MultilineEnabled $True -SinglelineEnabled $False

This example removes only multi-line comments from all C# files in the specified directory.

#>

param (
  [string]$DirectoryPath,
  [Parameter()]
  [bool]$SinglelineEnabled = $True,
  [Parameter()]
  [bool]$MultilineEnabled = $True
)

function Get-CsFilePaths {
  [CmdletBinding()]
  param (
    [Parameter(Mandatory = $True)]
    [string]$DirectoryPath
  )

  $filePaths = @()
  Get-ChildItem -Path $DirectoryPath -Recurse -Include *.cs | Where-Object { $_.Name -notlike "*.designer.cs" } | ForEach-Object {
    $filePaths += $_.FullName
  }

  return $filePaths
}

function Test-IsUtf8Bom {
  [CmdletBinding()]
  param (
    [Parameter(Mandatory = $True, Position = 0)]
    [string]$Path
  )
  
  $fileBytes = [System.IO.File]::ReadAllBytes($Path)
  $encoding = [System.Text.Encoding]::GetEncoding(0) # default encoding
  $encodingType = $encoding.GetString($fileBytes[0..2])
  
  if ($encodingType -eq "ï»¿") {
    return $True
  }
  else {
    return $False
  }
}

function Remove-CsComments {
  [CmdletBinding()]
  param (
    [Parameter(Mandatory = $True)]
    [string]$FilePath,
    [Parameter()]
    [bool]$SinglelineEnabled = $True,
    [Parameter()]
    [bool]$MultilineEnabled = $True
  )

  $content = Get-Content $FilePath
  $newContent = ""

  $isMultilineComment = $False
  foreach ($line in $content) {
    if ($MultilineEnabled -and $isMultilineComment) {
      if ($line -match '\*/') {
        $line = $line -replace '.*\*/'
        $isMultilineComment = $False
        if ([string]::IsNullOrWhiteSpace($line)) {
          continue
        }
      }
      else {
        continue
      }
    }

    if ($SinglelineEnabled) {
      if ($line -match '(?<!")//.*') {
        $line = $line -replace '\s*//.*', ''
        if ([string]::IsNullOrWhiteSpace($line)) {
          continue
        }
      }
    }

    if ($MultilineEnabled) {
      if ($line -match '/\*.*\*/') {
        $line = $line -replace '\s*/\*.*\*/', ''
        if ([string]::IsNullOrWhiteSpace($line)) {
          continue
        }
      }
      elseif ($line -match '/\*.*') {
        $line = $line -replace '\s*/\*.*', ''
        $isMultilineComment = $true
        if ([string]::IsNullOrWhiteSpace($line)) {
          continue
        }
      }
    }
      
    $newContent += $line + [Environment]::NewLine
  }

  if (Test-IsUtf8Bom -Path $FilePath) {
    Set-Content -Path $FilePath -Value $newContent -Encoding utf8BOM -NoNewline
  }
  else {
    Set-Content -Path $FilePath -Value $newContent -Encoding utf8NoBOM -NoNewline
  }
}

function Remove-CsCommentsFromFiles {
  [CmdletBinding()]
  param (
    [Parameter(Mandatory = $True)]
    [string[]]$FilePaths,
    [Parameter()]
    [bool]$SinglelineEnabled = $True,
    [Parameter()]
    [bool]$MultilineEnabled = $True
  )

  foreach ($filePath in $filePaths) {
    Remove-CsComments -FilePath $filePath -SinglelineEnabled $SinglelineEnabled -MultilineEnabled $MultilineEnabled
  }
}

Write-Host "Removing comments from '$DirectoryPath'"
$csFilePaths = Get-CsFilePaths -DirectoryPath $DirectoryPath
Remove-CsCommentsFromFiles -FilePaths $csFilePaths -SinglelineEnabled $SinglelineEnabled -MultilineEnabled $MultilineEnabled
