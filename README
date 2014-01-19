***************************** Webgoat.NET **********************************
* Source Code: https://github.com/jerryhoff/WebGoat.NET
* Download zip: https://github.com/jerryhoff/WebGoat.NET/zipball/master
****************************************************************************

This web application is a learning platform that attempts to teach about
common web security flaws. It contains generic security flaws that apply to
most web applications. It also contains lessons that specifically pertain to
the .NET framework. The excercises in this app are intented to teach about 
web security attacks and how developers can overcome them.

WARNING: THIS WEB APPLICATION CONTAINS NUMEROUS SECURITY VULNERABILITIES 
WHICH WILL RENDER YOUR COMPUTER VERY INSECURURE WHILE RUNNING! IT IS HIGHLY
RECOMMENDED TO COMPLETELY DISCONNECT YOUR COMPUTER FROM ALL NETWORKS WHILE
RUNNING!

Notes:
 - Google Chrome performs filtering for reflected XSS attacks. These attacks
   will not work unless chrome is run with the argument 
   --disable-xss-auditor. 
- Some (but not all!) of the lessons require a working SQL database. Setup
  guidelines are shown below.

How To Build And Run under Mac OS X and Linux:
  1. Prerequisites
     a. Mono framework for your respective OS. It can be downloaded at
        http://www.go-mono.com/mono-downloads/download.html. Make sure
        that ALL components get installed, including GTK and xsp.
     b. A DB for some of the lessions. Sqlite3 is recommended as it's
        faster and easier to use for the purposes of these lessions.
        Binaries can be found here: http://www.sqlite.org/download.html
  2. Install the mono framework and sqlite3 binaries.
  3. IMPORTANT: Make sure that the the mono executable is in your PATH.
  4. Grab WebGoat.NET and cd into the root dir.
  5. Run 'xbuild'. There may be a few warnings but there should be no 
     errors! If there are please let us know.
  6. cd into the WebGoat project and run 'xsp4'. Then open your favorite
     browser and go to http://localhost:8080 (or whatever port your
     xsp4 is using if you're not using the default). Note: The first run
     may take take some time as it's compiling everything on the fly.
  7. If you see the WebGoat.NET page that means you're almost there! Next
     step is to click on 'Set Up Database!'
  8. You should see a form with a bunch of setup information for the
     database. For 'Data Provider' choose Sqlite. For 'Data File Path' put
     in 'db.sqlite3' and for 'Client Executable' put in the sqlite3
     executable of your OS (usually /usr/bin/sqlite3).
  9. Click on 'Test Configuration', followed by 'Rebuild Database' and
     hopefully you should be good go! Enjoy your hackathon!

How to build and run under Windows:
  1. Prerequisites:
     a. Visual Studio 2010 and above.
     b. Mysql database that's up and running with at least one user
        aleady setup with full permissions.
  2. Open WebGoat.sln file via Visual Studio, and click on debug.
  3. You should see the WebGoat.NET page at which point click on
     'Set Up Database'.
  3. You should see a form with a bunch of setup information for the
     database. For 'Data Provider' choose MySql. You'll need to fill in
     the respective data entries for your mysql db. 'Client Executable'
     and 'Data File Path' are not necessary for MySql so you can leave
     them empty.
  4. Click on 'Test Configuration', followed by 'Rebuild Database' and
     hopefully you should be good go! Enjoy your hackathon!
