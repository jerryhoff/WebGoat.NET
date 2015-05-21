<%@ Page Language="C#" AutoEventWireup="true" EnableTheming="false" CodeBehind="Invoice.aspx.cs" Inherits="OWASP.WebGoat.NET.WebGoatCoins.Invoice" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
  <head runat="server">
    <title>Invoice</title>
    <link rel="stylesheet" href="../Resources/css/bootstrap.css"/>
  </head>
  <body>
    <div class="container">
      <div class="row">
        <div class="col-xs-6 text-right">
          <h1>INVOICE</h1>
          <h1><small>Invoice #001</small></h1>
        </div>
      </div>
      <div class="row">
        <div class="col-xs-5">
          <div class="panel panel-default">
            <div class="panel-heading">
              <h4>From: WebGoat.NET Inc.</h4>
            </div>
          </div>
        </div>
        <div class="col-xs-5 col-xs-offset-2 text-right">
          <div class="panel panel-default">
            <div class="panel-heading">
                <h4>To : <asp:Label runat="server" ID="lblFullName"/> </h4>
            </div>
            <div class="panel-body">
              <p>
                Country: <asp:Label runat="server" ID="lblCountry"/> <br/>
                Address: <asp:Label runat="server" ID="lblAddress"/> <br/>
              </p>
            </div>
          </div>
        </div>
      </div>
      <!-- / end client details section -->
      <table class="table table-bordered">
        <thead>
          <tr>
            <th>
              <h4>PartNo</h4>
            </th>
            <th>
              <h4>Description</h4>
            </th>
            <th>
              <h4>Qty</h4>
            </th>
            <th>
              <h4>Price</h4>
            </th>
            <th>
              <h4>Sub Total</h4>
            </th>
          </tr>
        </thead>
        <tbody>
          <tr>
            <td><asp:Label runat="server" ID="lblPartNo"/></td>
            <td><asp:Label runat="server" ID="lblDescription"/></td>
            <td class="text-right">1</td>
            <td class="text-right">$<asp:Label runat="server" ID="lblPrice"/></td>
            <td class="text-right">$<asp:Label runat="server" ID="lblSubTotal"/></td>
          </tr>
        </tbody>
      </table>
      <div class="row text-right">
        <div class="col-xs-2 col-xs-offset-8">
          <p>
            Shipping Rate: <br/>  
            <strong>
            Total : <br/>
            </strong>
          </p>
        </div>
        <div class="col-xs-2">
          $<asp:Label runat="server" ID="lblShippingRate"/> <br>
          <strong>
          $<asp:Label runat="server" ID="lblTotal"/> <br>
          </strong>
        </div>
      </div>
      <div class="row">
        <div class="col-xs-5">
          <div class="panel panel-info">
            <div class="panel-heading">
              <h4>Bank details</h4>
            </div>
            <div class="panel-body">
              <p>Your Name</p>
              <p>Bank Name</p>
              <p>SWIFT : --------</p>
              <p>Account Number : --------</p>
              <p>IBAN : --------</p>
            </div>
          </div>
        </div>
        <div class="col-xs-7">
          <div class="span7">
            <div class="panel panel-info">
              <div class="panel-heading">
                <h4>Contact Details</h4>
              </div>
              <div class="panel-body">
                <p>
                  Email : you@example.com <br><br>
                  Mobile : -------- <br> <br>
                </p>
                <h4>Payment should be made by Bank Transfer</h4>
              </div>
            </div>
          </div>
        </div>
      </div>
    </div>
  </body>
</html>
