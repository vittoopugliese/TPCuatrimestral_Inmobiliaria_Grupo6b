<%@ Page Title="Inmobiliaria" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="TPCuatrimestral_Inmobiliaria_Grupo6b._Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <!-- Zona central donde tenemos el buscador, imagen, etc -->
    <div class="backing py-5 text-center d-flex flex-column justify-content-center align-items-center">
            <style>
                .backing {
                    background-image: url("./pictures/fondoCasaModerna.png");
                    background-size: cover;
                    background-position: center;
                    background-repeat: no-repeat;
                    height: 754px;
                    position: relative;
                }

                .backing-overlay {
                    position: absolute;
                    top: 0;
                    left: 0;
                    right: 0;
                    bottom: 0;
                    background-color: rgba(0, 0, 0, 0.4);
                    z-index: 1;
                    pointer-events: none;
                }

                .backing-content {
                    position: relative;
                    z-index: 2;
                    width: 100%;
                }

                .propiedades-container {
                    display: flex;
                    flex-wrap: wrap;
                    align-items: center;
                    justify-content: center;
                    gap: 45px; 
                }

                .property-card {
                    width: 100%;
                    max-width: 454px;
                    margin: 0px 15px 0px 15px;
                    display: inline-block;
                    vertical-align: top;
                    transition: 150ms all ease-in-out;
                    box-shadow: 0 2px 6px rgba(0,0,0,0.1);
                    border-radius: 10px !important;
                }

                .property-image {
                   border-radius: 10px 10px 0 0 !important;
                   width: 100%;
                   height: 100%;
                   max-height: 200px;
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
        </style>

   <div class="backing-overlay"></div> 

   <div class="backing-content">
        <div class="container">
            <h1 class="display-5 text-light fw-bold fs-1">Encontrá el hogar de tus sueños</h1>
            <p class="lead text-light fs-3">Las mejores ofertas inmobiliarias de la Argentina</p>

            <!-- codigo para boton BUSCAR, aca empieza el div -->

            <div class="row g-2 justify-content-center mt-4">
                <div class="col-md-4">
                    <asp:TextBox ID="txtUbicacion" runat="server" CssClass="form-control" Placeholder="Ingresa la ubicacion " />
                </div>
                <div class="col-md-2">
                    <asp:DropDownList ID="ddlTipo" runat="server" CssClass="form-select">
                        <asp:ListItem>Comprar</asp:ListItem>
                        <asp:ListItem>Alquilar</asp:ListItem>
                    </asp:DropDownList>
                </div>
                <div class="col-md-2">
                    <asp:Button ID="btnBuscar" runat="server" Text="Buscar" CssClass="btn btn-seteado w-100" />
                </div>
            </div>

        </div>
        </div>
  </div>

    <!-- Propiedades destacadas: abajo podemos agregar las cards con el comando foreach como hizo Maxi en su video -->
    <div class="container py-3">
        <h2 class="mb-4">Propiedades destacadas</h2>
        <div class="row g-4">
        <%-- Repeater de cards de propiedades --%>
        <div class="propiedades-container">
            <asp:Repeater ID="rptPropiedades" runat="server">
                    <ItemTemplate>
                        <div class="property-card">
                            <div class="row g-0">

                                <img src='<%# Eval("ImagenUrl") %>' class="property-image" alt="Propiedad" />
                                
                                <div class="col-md-8">
                                    <div class="card-body p-4">
                                        <div class="d-flex justify-content-between align-items-start mb-2">
                                            <div>
                                                <h5 class="card-title text-dark mb-1"><%# Eval("Titulo") %></h5>
                                                <p class="text-muted mb-0">
                                                    <i class="fas fa-map-marker-alt"></i> <%# Eval("Ubicacion") %>
                                                </p>
                                            </div>
                                        </div>

                                        <div class="d-flex flex-row justify-content-between w-100 align-items-center">
                                            <b class="fs-4 mb-2">$<%# Eval("Precio") %></b>
                                            <a class="d-flex gap-2 align-items-center text-secondary text-decoration-none fst-italic" href="InmuebleSeleccionado.aspx"><i class="fas fa-eye"></i>Ver Propiedad</a>
                                        </div>
                                        
                                    </div>
                                </div>
                            </div>
                        </div>
                    </ItemTemplate>
                </asp:Repeater>
            </div>

        </div>
    </div>
</asp:Content>