<%@ Page Title="Validar Publicacion" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ValidarPublicaciones.aspx.cs" Inherits="TPCuatrimestral_Inmobiliaria_Grupo6b.ValidarPublicaciones" %>


<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
        <div class="container mt-4">
            <h2 class="mb-4">Revisiones Pendientes</h2>

            <asp:GridView ID="GridRevisiones" runat="server" AutoGenerateColumns="False"
                CssClass="table table-striped"
                OnRowCommand="GridRevisiones_RowCommand"
                DataKeyNames="IdRevision,IdPropiedad">
                <Columns>
                    <asp:BoundField DataField="IdRevision" HeaderText="ID" />
                    <asp:BoundField DataField="TipoAccion" HeaderText="Acción" />
                    <asp:BoundField DataField="FechaAccion" HeaderText="Fecha" DataFormatString="{0:dd/MM/yyyy HH:mm}" />
                    <asp:ButtonField ButtonType="Button" CommandName="Ver" Text="Ver Detalles" />
                    <asp:ButtonField ButtonType="Button" CommandName="Revisar" Text="Marcar como Revisado" />
                    <asp:ButtonField ButtonType="Button" CommandName="Rechazar" Text="Rechazar" />
                </Columns>
            </asp:GridView>


            <asp:Panel ID="PanelDetalle" runat="server" Visible="false" CssClass="card mt-4 p-3 border shadow-sm">
                <h4 class="mb-3">Detalle de la Propiedad</h4>
                <p><strong>Título:</strong> <asp:Label ID="LabelTitulo" runat="server" /></p>
                <p><strong>Tipo de Operación:</strong> <asp:Label ID="LabelTipoOperacion" runat="server" /></p>
                <p><strong>Tipo de Propiedad:</strong> <asp:Label ID="LabelTipo" runat="server" /></p>
                <p><strong>Dirección:</strong> <asp:Label ID="LabelDireccion" runat="server" /></p>
                <p><strong>Localidad:</strong> <asp:Label ID="LabelLocalidad" runat="server" /></p>
                <p><strong>Provincia:</strong> <asp:Label ID="LabelProvincia" runat="server" /></p>
                <p><strong>Ambientes:</strong> <asp:Label ID="LabelAmbientes" runat="server" /></p>
                <p><strong>Antigüedad:</strong> <asp:Label ID="LabelAntiguedad" runat="server" /></p>
                <p><strong>Precio:</strong> <asp:Label ID="LabelPrecio" runat="server" /></p>
                <p><strong>Expensas:</strong> <asp:Label ID="LabelExpensas" runat="server" /></p>
                <p><strong>Superficie Cubierta:</strong> <asp:Label ID="LabelSupCubierta" runat="server" /></p>
                <p><strong>Superficie Total:</strong> <asp:Label ID="LabelSupTotal" runat="server" /></p>
                <p><strong>Dormitorios:</strong> <asp:Label ID="LabelDormitorios" runat="server" /></p>
                <p><strong>Baños:</strong> <asp:Label ID="LabelBanos" runat="server" /></p>
                <p><strong>Descripción:</strong> <asp:Label ID="LabelDescripcion" runat="server" /></p>
            </asp:Panel>


            <asp:Panel ID="PanelRechazo" runat="server" Visible="false" CssClass="card mt-4 p-3 border">
                <h5>Motivo del rechazo</h5>
                <asp:HiddenField ID="HiddenIdRevision" runat="server" />
                <asp:TextBox ID="txtObservacion" runat="server" TextMode="MultiLine" Rows="4" CssClass="form-control" />
                <br />
                <asp:Button ID="btnConfirmarRechazo" runat="server" Text="Confirmar Rechazo" CssClass="btn btn-danger"
                    OnClick="btnConfirmarRechazo_Click" />
            </asp:Panel>

        </div>
</asp:Content>