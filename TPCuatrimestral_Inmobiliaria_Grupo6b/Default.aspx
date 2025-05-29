<%@ Page Title="Inmobiliaria" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="TPCuatrimestral_Inmobiliaria_Grupo6b._Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <!-- Zona central donde tenemos el buscador, imagen, etc -->
    <div class="backing py-5 text-center">
            
            <style>
                .backing {
                    background-image: url('pictures/fondoCasa.png');
                    background-size: cover;
                    background-position: center;
                    background-repeat: no-repeat;
                    height: 400px;
                    position: relative;
                }
            </style>

        <div class="container">
            <h1 class="display-5" style="color: black; font-weight: bold;">Encontrá el hogar de tus sueños</h1>
            <p class="lead" style="color: black; font-weight: bold;">Las mejores ofertas inmobiliarias de Argentina</p>

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

    <!-- Propiedades destacadas: abajo podemos agregar las cards con el comando foreach como hizo Maxi en su video -->
    <div class="container py-5">
        <h2 class="mb-4">Propiedades destacadas</h2>
        <div class="row g-4">

            <!-- Card 1 -->
            <div class="col-md-4">
                <div class="card">
                    <img src="https://upload.wikimedia.org/wikipedia/commons/a/a3/Image-not-found.png" class="card-img-top" alt="Caseros" />
                    <div class="card-body">
                        <h5 class="card-title">Departamento 2 ambientes en Caseros, Buenos Aires</h5>
                        <p class="card-text">75 m² · Balcon · Zona residencial</p>
                        <a href="#" class="btn btn-seteado">Detalles</a>
                    </div>
                </div>
            </div>


        </div>
    </div>

</asp:Content>