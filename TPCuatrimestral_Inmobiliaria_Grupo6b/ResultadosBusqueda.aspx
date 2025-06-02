<%@ Page Title="Resultados de Búsqueda" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ResultadosBusqueda.aspx.cs" Inherits="TPCuatrimestral_Inmobiliaria_Grupo6b.ResultadosBusqueda" %>

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
        

        .filters-card {
            background: white;
            border: 1px solid #dee2e6;
            border-radius: 15px;
            padding: 25px;
            box-shadow: 0 2px 8px rgba(0,0,0,0.1);
            margin-bottom: 30px;
        }
        
        .filter-section {
            margin-bottom: 20px;
        }
        
        .filter-title {
            color: #333;
            font-weight: 600;
            margin-bottom: 10px;
        }
        
        .results-header {
            background: linear-gradient(135deg, #ee6c4d, #f4a261);
            color: white;
            border-radius: 15px;
            padding: 20px;
            margin-bottom: 25px;
            text-align: center;
        }
        
        .btn-filter {
            background-color: #ee6c4d;
            border-color: #ee6c4d;
            color: white;
            transition: all 150ms ease-in;
        }
        
        .btn-filter:hover {
            scale: 1.01;
        }
        
        .btn-clear {
            background-color: #6c757d;
            border-color: #6c757d;
            color: white;
            transition: all 150ms ease-in;
        }
        
        .btn-clear:hover {
            scale: 1.01;
        }
    </style>

    <div class="container mt-5 mb-5">

        <div class="row mb-4">
            <div class="col-12">
                <h1 class="fs-2 text-dark">Buscar Propiedades</h1>
                <p class="fs-4 text-muted">Realizá una busqueda con nuestro sistema de filtrado</p>
            </div>
        </div>

        <div class="filters-card">
            <h4 class="filter-title mb-4">
                <i class="fas fa-filter"></i> Filtros de Búsqueda
            </h4>
            
            <div class="row">
                <div class="col-md-3 filter-section">
                    <label class="form-label filter-title">Provincia</label>
                    <div class="form-group">
                        <asp:DropDownList ID="DropDownListProvincia" runat="server" CssClass="form-control" Width="80%"></asp:DropDownList>
                    </div>
                </div>
                
                <div class="col-md-3 filter-section">
                    <label class="form-label filter-title">Operación</label>
                    <asp:DropDownList ID="ddlOperacion" runat="server" CssClass="form-select">
                        <asp:ListItem Text="Seleccionar Operacion" Value="" Selected="True" />
                        <asp:ListItem Text="Comprar" Value="Venta" />
                        <asp:ListItem Text="Alquilar" Value="Alquiler" />
                    </asp:DropDownList>
                </div>
                
                <div class="col-md-3 filter-section">
                    <label class="form-label filter-title">Tipo de Inmueble</label>
                    <asp:DropDownList ID="ddlTipoInmueble" runat="server" CssClass="form-select">
                        <asp:ListItem Text="Todos los tipos" Value="" Selected="True" />
                        <asp:ListItem Text="Departamento" Value="Departamento" />
                        <asp:ListItem Text="Casa" Value="Casa" />
                        <asp:ListItem Text="Loft" Value="Loft" />
                        <asp:ListItem Text="Oficina" Value="Oficina" />
                        <asp:ListItem Text="Local" Value="Local" />
                    </asp:DropDownList>
                </div>
                
                <div class="col-md-3 filter-section">
                    <label class="form-label filter-title">Rango de Precio</label>
                    <asp:DropDownList ID="ddlPrecio" runat="server" CssClass="form-select">
                        <asp:ListItem Text="Cualquier precio" Value="" Selected="True" />
                        <asp:ListItem Text="Hasta USD 100,000" Value="0-100000" />
                        <asp:ListItem Text="USD 100,000 - 200,000" Value="100000-200000" />
                        <asp:ListItem Text="USD 200,000 - 300,000" Value="200000-300000" />
                        <asp:ListItem Text="Más de USD 300,000" Value="300000-999999999" />
                    </asp:DropDownList>
                </div>
            </div>
            
            <div class="row mt-4">
                <div class="col-12 text-center">
                    <asp:Button ID="btnFiltrar" runat="server" Text="Aplicar Filtros" CssClass="btn btn-filter btn-lg me-3" OnClick="btnFiltrar_Click" />
                    <asp:Button ID="btnLimpiarFiltros" runat="server" Text="Limpiar Filtros" CssClass="btn btn-clear btn-lg" OnClick="btnLimpiarFiltros_Click" />
                </div>
            </div>
        </div>

        <div class="results-header">
            <h1 class="mb-2">
                <asp:Label ID="lblResultadosCount" runat="server" Text="0" />
            </h1>
            <p class="mb-0 fs-5">Propiedades encontradas</p>
        </div>

        <div class="row">
            <div class="col-12">
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
                                        
                                        <p class="fs-4 mb-2"><%# Eval("Precio") %></p>
                                        
                                        <p class="card-text text-muted mb-3"><%# Eval("Descripcion") %></p>
                                        
                                        <div class="row">
                                            <div class="col-md-6 mb-2">
                                                <p class="mb-1 small"><strong>Tipo:</strong> <%# Eval("Tipo") %></p>
                                                <p class="mb-1 small"><strong>Superficie:</strong> <%# Eval("Superficie") %> m²</p>
                                                <p class="mb-0 small"><strong>Publicado:</strong> <%# Eval("FechaPublicacion", "{0:dd/MM/yyyy}") %></p>
                                            </div>
                                            <div class="col-md-6">
                                                <div class="d-flex flex-column gap-2">
                                                <!-- BOTONES -->
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </ItemTemplate>
                </asp:Repeater>
                
                <asp:Panel ID="pnlSinResultados" runat="server" Visible="false" CssClass="text-center py-5">
                    <div class="alert alert-warning">
                        <h4>No se encontraron propiedades</h4>
                        <p>Intenta modificar los filtros de búsqueda para encontrar más resultados.</p>
                        <asp:Button ID="btnVolverBuscar" runat="server" 
                            Text="Limpiar Filtros" 
                            CssClass="btn btn-seteado" 
                            OnClick="btnLimpiarFiltros_Click" />
                    </div>
                </asp:Panel>
            </div>
        </div>
        
        </div>
    </div>

    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/6.0.0/css/all.min.css">
</asp:Content>