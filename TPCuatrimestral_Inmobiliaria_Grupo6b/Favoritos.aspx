<%@ Page Title="Favoritos" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Favoritos.aspx.cs" Inherits="TPCuatrimestral_Inmobiliaria_Grupo6b.Favoritos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    
    <style>
        /* el container interno del repetidor de cards */
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
            cursor: pointer;
        }
                
        .property-card:hover {
            box-shadow: 0 4px 15px rgba(0,0,0,0.15);
            transform: translateY(-2px);
        }

        .property-card .col-md-8 {
            width: 100%;
        }
        
        .price-tag {
            color: #ee6c4d;
            font-size: 1.5rem;
            font-weight: bold;
        }
        
        .heart-icon{
            position: absolute;
            top: 10px;
            right: 10px;
            font-size: 24px;
            color: #ff0000;
            text-shadow: 0 0 5px rgba(0,0,0,0.5);
            cursor: pointer;
            transition: all 200ms ease-in-out;
            z-index: 10;
        }

        .heart-icon:hover {
            transform: scale(1.1);
        }

        .card-clickable {
            cursor: pointer;
        }
    </style>

    <div class="container mt-5 mb-5">

        <div class="row mb-4">
            <div class="col-12">
                <h1 class="fs-2 text-dark">Publicaciones en Favoritos</h1>
                <p class="fs-4 text-muted">Aca se muestran tus propiedades guardadas</p>
            </div>
        </div>

        <div class="propiedades-container">
            <asp:Repeater ID="rptPropiedades" runat="server" OnItemCommand="rptPropiedades_ItemCommand">
                    <ItemTemplate>
                        <div class="property-card">
                            <div class="row g-0">
                                <div style="position: relative;">
                                  <div class="card-clickable" onclick="window.location.href='InmuebleSeleccionado.aspx?id=<%# Eval("IdPropiedad") %>';">
                                    <img src='<%# Eval("ImagenUrl") %>' class="property-image" alt="Propiedad" />
                                  </div>
                                  
                                  <asp:LinkButton ID="btnFavorito" runat="server" 
                                                  CommandName="AlternarFavorito" 
                                                  CommandArgument='<%# Eval("IdPropiedad") %>'
                                                  CssClass="heart-icon">
                                      <i class="fas fa-heart"></i>
                                  </asp:LinkButton>
                                </div>
                                
                                <div class="col-md-8">
                                    <div class="card-body p-4 card-clickable" onclick="window.location.href='InmuebleSeleccionado.aspx?id=<%# Eval("IdPropiedad") %>';">
                                        <div class="d-flex justify-content-between align-items-start mb-2">
                                            <div>
                                                <h5 class="card-title text-dark mb-1"><%# Eval("Titulo") %></h5>
                                                <p class="text-muted mb-0">
                                                    <i class="fas fa-map-marker-alt"></i> <%# Eval("Ubicacion") %>
                                                </p>
                                            </div>
                                        </div>
                                        
                                        <b class="fs-4 mb-2">$<%# Eval("Precio") %></b>
                                        
                                        <p class="card-text text-muted mb-3"><%# Eval("Descripcion") %></p>
                                        
                                        <div class="d-flex gap-2 align-items-center row">
                                            <div class="d-flex flex-row gap-3 align-items-center">
                                                <i class="fas fa-door-open"></i> <%# Eval("Ambientes") %> Amb.</p>
                                                <i class="fas fa-bed"></i> <%# Eval("Dormitorios") %> Dorm. </p>
                                                <i class="fas fa-bath"></i> <%# Eval("Baños") %> Bañ. </p>
                                            </div>
                                            <div class="d-flex flex-row gap-3 align-items-center">
                                                <i class="fas fa-ruler-combined"></i> <%# Eval("Sup_m2_Total") %> m²
                                                <%# Eval("ConPatio").ToString() == "True" ? "<i class='fas fa-tree'></i> Con Patio" : "<i class='fas fa-tree'></i> Sin Patio"%>
                                                <%# Eval("ConBalcon").ToString() == "True" ? "<i class='fas fa-umbrella-beach'></i> Con Balcón" : "<i class='fas fa-umbrella-beach'></i> Sin Balcón"%>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </ItemTemplate>
                </asp:Repeater>
                
                <asp:Panel ID="pnlSinResultados" runat="server" Visible="false" CssClass="text-center py-5">
                    <div class="alert alert-warning px-5">
                        <h3>No se encontraron Favoritos</h3>
                        <p class="fs-5">Para agregar a esta lista toca el icono de Corazon en alguna Propiedad.</p>
                    </div>
                </asp:Panel>
            </div>
        </div>
        
</asp:Content>