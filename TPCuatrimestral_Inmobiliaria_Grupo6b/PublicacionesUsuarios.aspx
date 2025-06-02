<%@ Page Title="Mis Publicaciones" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="PublicacionesUsuario.aspx.cs" Inherits="TPCuatrimestral_Inmobiliaria_Grupo6b.PublicacionesUsuarios" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    
    <style>
        .property-card {
            width: 100%;
            max-width: 540px;
            margin: 15px;
            display: inline-block;
            vertical-align: top;
        }

        /* el container interno del repetidor de cards */
        .propiedades-container {
            display: flex;
            flex-wrap: wrap;
            align-items: center;
            justify-content: center;
            gap: 30px; 
        }

        .property-card .row {
            display: block;
        }

        .property-image {
            border-radius: 10px 10px 0 0 !important;
            width: 100%;
            height: 200px;
        }

        .property-card .col-md-8 {
            width: 100%;
        }
        
        .property-card:hover {
            box-shadow: 0 4px 15px rgba(0,0,0,0.12);
            scale: 1.02;
        }
        
        .property-image {
            height: 300px;
            object-fit: cover;
        }
        
        .visit-counter {
            background-color: #f8f9fa;
            border-radius: 20px;
            padding: 5px 12px;
            font-size: 0.85rem;
            color: #6c757d;
        }
        
        .heart-icon {
            color: #dc3545;
            font-size: 1.3rem;
            cursor: pointer;
            transition: transform 0.2s ease;
        }
        
        .heart-icon:hover {
            transform: scale(1.1);
        }
        
        .stats-card {
            background: linear-gradient(135deg, #ee6c4d, #f4a261);
            color: white;
            border-radius: 15px;
            padding: 22px;
            text-align: center;
            box-shadow: 0 4px 15px rgba(238, 108, 77, 0.3);
            transition: 200ms all ease-in-out;
            user-select: none;
        }
        
        .account-info-card {
            background: white;
            border: 1px solid #dee2e6;
            border-radius: 15px;
            padding: 25px;
            box-shadow: 0 2px 8px rgba(0,0,0,0.1);
            transition: 200ms all ease-in-out;
            user-select: none;
        }
                
        .stats-card:hover {
            scale: 0.98;
        }

        
        .account-info-card:hover {
            scale: 0.98;
        }
    </style>

    <div class="container" style="margin-top: 3rem; margin-bottom: 3rem;">
        
        <div class="row mb-4">
            <div class="col-12">
                <h1 class="fs-2 text-dark">Mis Publicaciones</h1>
                <p class="fs-4 text-muted">Gestiona tus propiedades publicadas</p>
            </div>
        </div>

        <div class="d-flex align-items-center row mb-4">
            <div class="col-md-6 mb-3">
                <div class="stats-card">
                    <h3 class="mb-2 fs-1">
                        <asp:Label ID="lblPublicacionesActivas" runat="server" Text="0" />
                    </h3>
                    <p class="mb-0 fs-5">Publicaciones Activas</p>
                </div>
            </div>
            
            <div class="col-md-6 mb-3">
                <div class="account-info-card">
                    <p class="mb-1"><strong>Usuario:</strong> <asp:Label ID="lblNombreUsuario" runat="server" Text="Juan Pérez" /></p>
                    <p class="mb-1"><strong>Email:</strong> <asp:Label ID="lblEmailUsuario" runat="server" Text="juan.perez@email.com" /></p>
                    <p class="mb-0"><strong>Fecha registro:</strong> <asp:Label ID="lblFechaRegistro" runat="server" Text="15/03/2024" /></p>
                </div>
            </div>
        </div>

        <div class="row">
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
                                            <div class="d-flex align-items-center">
                                                <span class="visit-counter me-2">
                                                    <i class="fas fa-eye"></i> <%# Eval("Visitas") %> visitas
                                                </span>
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
                
                <asp:Panel ID="pnlSinPropiedades" runat="server" Visible="false" CssClass="text-center py-5">
                    <div class="alert alert-info">
                        <h4>No tienes publicaciones activas</h4>
                        <p>¡Publica tu primera propiedad y comienza a recibir consultas!</p>
                    </div>
                </asp:Panel>
            </div>
        </div>
        
    </div>

    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/6.0.0/css/all.min.css">

</asp:Content> 