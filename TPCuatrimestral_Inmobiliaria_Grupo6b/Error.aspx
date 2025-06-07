<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Error.aspx.cs" Inherits="TPCuatrimestral_Inmobiliaria_Grupo6b.Error" MasterPageFile="~/Site.master" %>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h1>Hubo un problema</h1>
    <asp:Label ID="lblMensaje" runat="server" Text="Ocurrió un error inesperado. Por favor, intenta nuevamente." CssClass="text-danger fs-4" />
</asp:Content>
