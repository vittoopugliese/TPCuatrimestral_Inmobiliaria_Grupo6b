﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="InmuebleSeleccionado.aspx.cs" Inherits="TPCuatrimestral_Inmobiliaria_Grupo6b.InmuebleSeleccionado" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">


    <div class="container" style="margin-top: 15px">

        <h1 class="card-title" id="tituloPropiedad" runat="server"></h1>

        <div class="card shadow-lg" style="margin-top: 15px; font-size: 20px">
            <div class="card-body">

                <p class="card-text" id="direccionPropiedad" runat="server"><span class="fa-solid fa-location-dot" style="margin-right: 10px"></span></p>
                <div class="row">
                    <div class="col-8">
                        <div id="propertyCarousel" class="carousel slide" data-bs-ride="carousel" data-bs-interval="5000">
                            <div class="carousel-inner" id="carouselInner" runat="server">
                                <!-- Las imágenes se cargarán dinámicamente -->
                            </div>
                            <button class="carousel-control-prev" type="button" data-bs-target="#propertyCarousel" data-bs-slide="prev">
                                <span class="carousel-control-prev-icon" aria-hidden="true"></span>
                                <span class="visually-hidden">Anterior</span>
                            </button>
                            <button class="carousel-control-next" type="button" data-bs-target="#propertyCarousel" data-bs-slide="next">
                                <span class="carousel-control-next-icon" aria-hidden="true"></span>
                                <span class="visually-hidden">Siguiente</span>
                            </button>
                        </div>

                        <div class="row" style="margin-top: 25px; display: flex; justify-content: center; align-items: center; font-size: 20px">

                            <div class="col">
                                <div style="position: absolute; bottom: 0; width: calc(100% - 30px); margin-left: 40px">
                                    <i class="fa-solid fa-sink"></i>
                                    <p>Baño</p>
                                </div>
                            </div>

                            <div class="col">
                                <div style="position: absolute; bottom: 0; width: calc(100% - 30px); margin-left: 40px">
                                    <i class="fa-solid fa-car-side"></i>
                                    <p>Cochera</p>
                                </div>
                            </div>

                            <div class="col">
                                <div style="position: absolute; bottom: 0; width: calc(100% - 30px); margin-left: 40px">
                                    <i class="fa-solid fa-bed"></i>
                                    <p>Dormitorios</p>
                                </div>
                            </div>

                            <div class="col">
                                <div style="position: absolute; bottom: 0; width: calc(100% - 30px); margin-left: 40px">
                                    <i class="fa-solid fa-house-user"></i>
                                    <p>Balcón</p>
                                </div>
                            </div>
                        </div>

                    </div>
                    <div class="col-4">

                        <div class="card">
                            <div class="card-body">

                                <label for="inputEmail4" class="form-label">CONTACTAR AL PROPIETARIO</label>
                                <input type="text" class="form-control" id="nombreyapellido" placeholder="Nombre y Apellido" style="margin-top: 10px">
                                <input type="tel" class="form-control" id="telefono" runat="server" placeholder="Teléfono" style="margin-top: 10px">
                                <input type="text" class="form-control" id="asunto" placeholder="Asunto" style="margin-top: 10px">
                                <input type="email" class="form-control" id="email" placeholder="Email" runat="server" style="margin-top: 10px">
                                <textarea class="form-control" id="mensajeContactar" runat="server" placeholder="Mensaje..." rows="3" style="margin-top: 10px"></textarea>
                                <div class="form-check form-switch">
                                    <input class="form-check-input" type="checkbox" id="flexSwitchCheckDefault" runat="server" style="margin-top: 15px">
                                    <label class="form-check-label" for="flexSwitchCheckDefault" style="margin-top: 10px">Recibir copia por email</label>
                                </div>
                                <asp:Button Text="Contactar" CssClass="btn btn-dark" ID="btnContactar" runat="server" Style="width: 100%; margin-top: 10px" OnClick="btnContactar_Click" />

                                <asp:Button Text="Enviar Whastapp" CssClass="btn btn-success" ID="botonWp" runat="server" Style="width: 100%; margin-top: 10px" OnClick="botonWp_Click" />


                            </div>
                        </div>

                        <div class="card" style="margin-top: 17px">
                            <div class="card-body">
                                <p id="nombrePropietario" runat="server">Nombre del Propietario</p>
                                <p><i class="fa-brands fa-whatsapp" style="margin-right: 10px"></i><span id="whatsappPropietario" runat="server">(011) 4263-5632</span></p>
                                <a href="mailto:ale_tama77@hotmail.com" id="emailPropietario" runat="server" style="text-decoration: none; color: inherit;">
                                    <p style="margin: 0; display: inline-block;">
                                        <i class="fa-solid fa-envelope" style="margin-right: 10px"></i>Enviar e-mail
                                    </p>
                                </a>

                            </div>
                        </div>
                    </div>
                </div>
            </div>

        </div>

        <div class="row">
            <div class="col-4">
                <h2 id="precioPropiedad" runat="server" style="margin-top: 15px">U$D</h2>
                <p>$40.000 de expensas</p>
            </div>

            <div class="col-4" style="margin-top: 20px; font-size: 20px">
                <div>
                    <i class="fa-solid fa-credit-card"></i>
                    <p>Apto Crédito!</p>
                </div>
            </div>

            <div class="col-4">
                <p id="fechaPublicacionPropiedad" runat="server" style="margin-top: 35px; font-size: 25px">Publicado el 01/06/2025</p>
            </div>
        </div>

        <hr />

        <div class="row">

            <div class="col">
                <div>
                    <i class="fa-solid fa-pen-ruler"></i>
                    <p>Ambientes</p>
                </div>
            </div>
            <div class="col">
                <div>
                    <i class="fa-solid fa-ruler-combined"></i>
                    <p>Sup. Total</p>
                </div>
            </div>

            <div class="col">
                <div>
                    <i class="fa-solid fa-pen-ruler"></i>
                    <p>Sup. Cubierta</p>
                </div>
            </div>

            <div class="col">
                <div>
                    <i class="fa-solid fa-tree"></i>
                    <p>Patio</p>
                </div>
            </div>

            <div class="col">
                <div>
                    <i class="fa-solid fa-pen-ruler"></i>
                    <p>Antiguedad</p>
                </div>
            </div>

        </div>

        <hr />

        <h2 style="margin-top: 15px">VENTA DE CASA EN AVELLANEDA, excelente !</h2>
        <p class="card-text">Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.</p>
    </div>



</asp:Content>
