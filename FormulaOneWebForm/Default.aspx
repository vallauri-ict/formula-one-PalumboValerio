<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="FormulaOneWebForm.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title> FormulaOne - WebForm </title>
    <style>
        body {
        background-image: url("img/Background.jpg");
		background-position: center;
		background-repeat: no-repeat;
		background-size: cover;
		background-attachment: fixed;
        }

        h1 {
        text-shadow: 0 1px 0 #ccc,
                     0 2px 0 #c9c9c9,
                     0 3px 0 #bbb,
                     0 4px 0 #b9b9b9,
                     0 5px 0 #aaa,
                     0 6px 1px rgba(0,0,0,.1),
                     0 0 5px rgba(0,0,0,.1),
                     0 1px 3px rgba(0,0,0,.3),
                     0 3px 5px rgba(0,0,0,.2),
                     0 5px 10px rgba(0,0,0,.25),
                     0 10px 10px rgba(0,0,0,.2),
                     0 20px 20px rgba(0,0,0,.15);
        margin: 0 auto;
        text-align: center;
        color: red;
        }


        #lstNazione
        {
        color: #fff;
        font-size: 20px;
        padding: 5px 10px;
        border-radius: 5px 12px;
        background-color: #292929;
        font-weight: bold;
        }

        #dgvNazione{
        width:100%;
        text-align:center;
        }

        .table-condensed tr th {
        border: 0px solid #6e7bd9;
        color: white;
        background-color: #6e7bd9;
        }

        .table-condensed, .table-condensed tr td {
        border: 0px solid #000;
        }

        tr:nth-child(even) {
        background: #f8f7ff
        }

        tr:nth-child(odd) {
        background: #fff;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h1>FORMULA ONE - WEB FORM</h1>
            <asp:DropDownList ID="lstNazione" runat="server" OnSelectedIndexChanged="lstNazione_SelectedIndexChanged" AutoPostBack="true" CssClass="form-control"></asp:DropDownList><br /><br />
            <asp:GridView ID="dgvNazione" runat="server" AutoPostBack="true" CssClass="table table-condensed table-hover"></asp:GridView>
        </div>
    </form>
</body>
</html>