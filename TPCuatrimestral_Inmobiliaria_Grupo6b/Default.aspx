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
                    gap: 30px; 
                }

                .property-card {
                    width: 100%;
                    max-width: 354px;
                    margin: 0px 15px 0px 15px;
                    display: inline-block;
                    vertical-align: top;
                    transition: 150ms all ease-in-out;
                    box-shadow: 0 2px 6px rgba(0,0,0,0.1);
                    border-radius: 10px !important;
                    cursor: pointer;
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

                .heart-icon{
                    position: absolute;
                    top: 10px;
                    right: 10px;
                    font-size: 24px;
                    color: white;
                    text-shadow: 0 0 5px rgba(0,0,0,0.5);
                    cursor: pointer;
                    transition: all 200ms ease-in-out;
                }

                .heart-icon:hover {
                    color: #ff0000 !important;
                    transform: scale(1.1);
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

  <div class="py-3">
        <h2 class="mb-5 mt-2 text-center">✨ Propiedades Destacadas 🏠</h2>

        <div class="row g-2">
            <div class="propiedades-container">
                <asp:Repeater ID="rptPropiedadesDestacadas" runat="server">
                        <ItemTemplate>
                            <div class="property-card" onclick="window.location.href='InmuebleSeleccionado.aspx?id=<%# Eval("IdPropiedad") %>';">
                                <div class="row g-0">
                                    <div style="position: relative;">
                                        <img src='<%# Eval("ImagenUrl") %>' class="property-image" alt="Propiedad" />
                                        <i class="fas fa-heart heart-icon"></i>
                                    </div>
                                
                                    <div class="col-md-8">
                                        <div class="card-body p-3">
                                            <div class="d-flex justify-content-between align-items-start mb-2">
                                                <div>
                                                    <h5 class="card-title text-dark mb-1"><%# Eval("Titulo") %></h5>
                                                    <p class="text-muted mb-0">
                                                        <i class="fas fa-map-marker-alt"></i> <%# Eval("Ubicacion") %>
                                                    </p>
                                                </div>
                                            </div>

                                            <b class="fs-4">$<%# Eval("Precio") %></b>
                                        
                                        
                                            <div class="d-flex gap-2 align-items-center row mt-2">
                                                <div class="d-flex flex-row gap-2 align-items-center">
                                                    <i class="fas fa-door-open"></i><%# Eval("Ambientes") %> Amb.</p>
                                                    <i class="fas fa-bed"></i><%# Eval("Dormitorios") %> Dorm. </p>
                                                    <i class="fas fa-bath"></i><%# Eval("Baños") %> Bañ. </p>
                                                </div>
                                                <div class="d-flex flex-row gap-2 align-items-center">
                                                    <i class="fas fa-ruler-combined"></i><%# Eval("Sup_m2_Total") %> m²
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
            </div>
        </div>
    </div>

    <div class="py-3">
      <h2 class="mb-5 mt-2 text-center">🎖 Propiedades Más Vistas 🏡</h2>

      <div class="row g-2">
          <div class="propiedades-container">
              <asp:Repeater ID="rptPropiedadesMasVistas" runat="server">
                      <ItemTemplate>
                          <div class="property-card" onclick="window.location.href='InmuebleSeleccionado.aspx?id=<%# Eval("IdPropiedad") %>';">
                              <div class="row g-0">
                                <div style="position: relative;">
                                    <img src='<%# Eval("ImagenUrl") %>' class="property-image" alt="Propiedad" />
                                    <i class="fas fa-heart heart-icon"></i>
                                </div>
                              
                                  <div class="col-md-8">
                                      <div class="card-body p-3">
                                          <div class="d-flex justify-content-between align-items-start mb-2">
                                              <div>
                                                  <h5 class="card-title text-dark mb-1"><%# Eval("Titulo") %></h5>
                                                  <p class="text-muted mb-0">
                                                      <i class="fas fa-map-marker-alt"></i> <%# Eval("Ubicacion") %>
                                                  </p>
                                              </div>
                                          </div>

                                          <b class="fs-4">$<%# Eval("Precio") %></b>
                                      
                                      
                                          <div class="d-flex gap-2 align-items-center row mt-2">
                                              <div class="d-flex flex-row gap-2 align-items-center">
                                                  <i class="fas fa-door-open"></i><%# Eval("Ambientes") %> Amb.</p>
                                                  <i class="fas fa-bed"></i><%# Eval("Dormitorios") %> Dorm. </p>
                                                  <i class="fas fa-bath"></i><%# Eval("Baños") %> Bañ. </p>
                                              </div>
                                              <div class="d-flex flex-row gap-2 align-items-center">
                                                  <i class="fas fa-ruler-combined"></i><%# Eval("Sup_m2_Total") %> m²
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
          </div>
      </div>
  </div>
</asp:Content>