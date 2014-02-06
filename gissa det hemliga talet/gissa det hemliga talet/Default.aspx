<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="gissa_det_hemliga_talet.Default" ViewStateMode="Disabled" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Gissa det hemliga talet</title>
    <link href="~/Style.css" rel="stylesheet" />
    <script src="/Scripts/jquery.js"></script>
    <script src="/Scripts/script.js"></script>
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <meta name="description" content="The description of my page" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <%-- input fält med valideringar och knappar--%>
            <asp:ValidationSummary CssClass="error" ID="ValidationSummary" runat="server" HeaderText="Ett fel skedde läs nedan om mer:" />
            <asp:Label ID="Label" runat="server" Text="Label">Ange ett tal mellan 1 och 100:</asp:Label><%-- Text --%>
            <asp:TextBox ID="TextBox" runat="server" autofocus="autofocus" Enabled="True"></asp:TextBox>
            <asp:RequiredFieldValidator CssClass="error" ID="RequiredFieldValidator" ControlToValidate="TextBox" runat="server" Text="*" ErrorMessage="Fältet är tomt var god försök igen" Display="Dynamic"></asp:RequiredFieldValidator><%-- Felmeddelande --%>
            <asp:RangeValidator CssClass="error" ID="RangeValidator" runat="server" ControlToValidate="TextBox" ErrorMessage="Ditt tal var inte ett tal eller inte ett tal mellan 1 och 100" Text="*" Display="Dynamic" Type="Integer" MinimumValue="1" MaximumValue="100"></asp:RangeValidator><%-- Felmeddelande  --%>
            <asp:Button ID="guess" runat="server" Text="Gissa" OnClick="guess_Click" /><%-- Knapp för gissningar --%>
            <%-- Textrad som kommer innehålla gissningar och meddelande --%>
            <asp:Label ID="guesses" runat="server" Text=""></asp:Label>
            <asp:Label ID="message" runat="server" Text=""></asp:Label>

            <%-- knapp för nytt tal --%>
            <asp:Button ID="new_number" CausesValidation="False" runat="server" Text="Skapa nytt tal" Visible="False" OnClick="ResetButton_Click" />
            <%-- Knapp som kommer synas när man har klarat spelet eller misslyckat --%>
        </div>
    </form>
</body>
</html>