<%@ Page  MasterPageFile="~/Site.Master" Language="C#" AutoEventWireup="true" CodeBehind="PublicacionesEliminadas.aspx.cs" Inherits="TPCuatrimestral_Inmobiliaria_Grupo6b.PublicacionesEliminadas" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <style>
     .propiedades-container {
        display: flex;
        flex-wrap: wrap;
        align-items: center;
        justify-content: center;
        gap: 45px;
     }

     .property-image {
         border-radius: 10px 10px 0 0 !important;
         width: 100%;
         height: 100%;
         max-height: 300px;
     }

     .property-card {
         width: 100%;
         max-width: 594px;
         margin: 0px 15px 0px 15px;
         display: inline-block;
         vertical-align: top;
         transition: 150ms all ease-in-out;
         box-shadow: 0 2px 6px rgba(0,0,0,0.1);
         border-radius: 10px !important;
     }

     .property-card:hover {
         box-shadow: 0 4px 15px rgba(0,0,0,0.15);
         transform: translateY(-2px);
     }

     .property-card .col-md-8 {
         width: 100%;
     }

     .property-card .col-md-8 {
         width: 100%;
     }

     .property-card:hover {
         box-shadow: 0 4px 15px rgba(0,0,0,0.12);
         scale: 1.01;
     }

     .property-image {
         height: 300px;
         object-fit: cover;
     }


     .hide-icon {
        cursor: pointer;
        background: none !important;
        border: none !important;
        text-decoration: none !important;
        outline: none !important;
        color: black;
     }
    </style>
<body>
        <div class="container mt-5 mb-5">
<div class="row">
    <div class="row mb-4">
        <div class="col-12">
            <h1 class="fs-2 text-dark">Publicaciones Eliminadas</h1>
            <p class="fs-4 text-muted">Gestiona tus propiedades eliminadas</p>
        </div>
    </div>

    <div class="propiedades-container">
        <asp:Repeater ID="rptPropiedades" runat="server">
            <ItemTemplate>
                <div class="property-card">
                    <div class="row g-0">
                        <img src='<%# Eval("ImagenUrl") %>' class="property-image" alt="Propiedad" />

                        <div class="col-md-8">
                            <div class="card-body p-3">
                                <div class="d-flex justify-content-between align-items-start mb-2">
                                    <div>
                                        <h5 class="card-title text-dark mb-1"><%# Eval("Titulo") %></h5>
                                        <p class="text-muted mb-0">
                                            <i class="fas fa-map-marker-alt"></i><%# Eval("Ubicacion") %>
                                        </p>
                                    </div>
                                </div>

                                <b class="fs-4 mb-2">$<%# Eval("Precio") %></b>
                                <p class="mb-0 small"><strong>Publicado:</strong> <%# Eval("FechaPublicacion", "{0:dd/MM/yyyy}") %></p>

<%--                                <asp:LinkButton CssClass="hide-icon" ID="lnkDesEliminar" runat="server" OnCommand="lnkOpcionesPublicacion_Command" CommandName="deseliminar" CommandArgument='<%# Eval("IdPropiedad") %>'>
                                    <p style="cursor:pointer;margin:0px;"><i class='fas fa-trash' style="color:lawngreen;"></i>Re-activar publicacion</p>
                                </asp:LinkButton>--%>

                            </div>
                        </div>
                    </div>
                </div>
            </ItemTemplate>
        </asp:Repeater>

        <asp:Panel ID="pnlSinPropiedades" runat="server" Visible="false" CssClass="text-center py-5">
            <div class="alert alert-danger">
                <h4>No tenes publicaciones eliminadas</h4>
                <p>Publica tu primera propiedad, eliminala y revisalas aca!</p>
            </div>
        </asp:Panel>
    </div>
</div>
</div>
</asp:Content>
