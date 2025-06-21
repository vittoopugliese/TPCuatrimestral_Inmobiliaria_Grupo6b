<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="InmuebleSeleccionado.aspx.cs" Inherits="TPCuatrimestral_Inmobiliaria_Grupo6b.InmuebleSeleccionado" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">


    <div class="container" style="margin-top: 15px">

        <div class="card shadow-lg" style="margin-top: 25px; font-size: 20px">
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
                                    <p id="banoPropiedad" runat="server"></p>
                                </div>
                            </div>

                            <div class="col" id="colCochera" runat="server">
                                <div style="position: absolute; bottom: 0; width: calc(100% - 30px); margin-left: 40px">
                                    <i class="fa-solid fa-car"></i>
                                    <p id="cocheraPropiedad" runat="server"></p>
                                </div>
                            </div>

                            <div class="col">
                                <div style="position: absolute; bottom: 0; width: calc(100% - 30px); margin-left: 40px">
                                    <i class="fa-solid fa-bed"></i>
                                    <p id="dormitoriosPropiedad" runat="server"></p>
                                </div>
                            </div>



                            <div class="col" id="colBalcon" runat="server">
                                <div style="position: absolute; bottom: 0; width: calc(100% - 30px); margin-left: 40px">
                                    <i class="fa-solid fa-house-user"></i>
                                    <p id="balconPropiedad" runat="server"></p>
                                </div>
                            </div>
                        </div>

                    </div>
                    <div class="col-4">

                        <div class="card">
                            <div class="card-body">
                                <label for="inputEmail4" class="form-label">CONTACTAR AL PROPIETARIO</label>
                                <asp:TextBox runat="server" ID="txtNombreApellido" CssClass="form-control" placeholder="Nombre y Apellido" Style="margin-top: 10px"></asp:TextBox>
                                <asp:TextBox runat="server" ID="txtTelefono" CssClass="form-control" placeholder="Teléfono" Style="margin-top: 10px"></asp:TextBox>
                                <asp:TextBox runat="server" ID="txtAsunto" CssClass="form-control" placeholder="Asunto" Style="margin-top: 10px"></asp:TextBox>
                                <asp:TextBox runat="server" ID="txtEmail" TextMode="Email" CssClass="form-control" placeholder="Email" Style="margin-top: 10px"></asp:TextBox>
                                <asp:TextBox runat="server" ID="txtMensaje" TextMode="MultiLine" Rows="3" CssClass="form-control" placeholder="Mensaje..." Style="margin-top: 10px"></asp:TextBox>
                                <div class="form-check form-switch">
                                    <input class="form-check-input" type="checkbox" id="flexSwitchCheckDefault" runat="server" style="margin-top: 15px">
                                    <label class="form-check-label" for="flexSwitchCheckDefault" style="margin-top: 10px">Recibir copia por email</label>
                                </div>
                                <asp:Button Text="Contactar" CssClass="btn btn-dark" ID="btnContactar" runat="server" Style="width: 100%; margin-top: 10px" OnClick="btnContactar_Click" />
                                <asp:Button Text="Enviar WhatsApp" CssClass="btn btn-success" ID="botonWp" runat="server" Style="width: 100%; margin-top: 10px" OnClick="botonWp_Click" />
                            </div>
                        </div>

                        <div class="card" style="margin-top: 17px">
                            <div class="card-body">
                                <p id="nombrePropietario" runat="server"></p>
                                <p><i class="fa-brands fa-whatsapp" style="margin-right: 10px"></i><span id="whatsappPropietario" runat="server"></span></p>
                                <a href="#" id="emailPropietario" runat="server" style="text-decoration: none; color: inherit;">
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
                <h2 id="precioCompleto" runat="server" style="margin-top: 15px"></h2>
                <p id="expensasPropiedad" runat="server"></p>
            </div>

            <div id="creditoPropiedad" class="col-4" style="margin-top: 20px; font-size: 20px" runat="server">
                <div>
                    <i class="fa-solid fa-credit-card"></i>
                    <p>Apto Crédito!</p>
                </div>
            </div>

            <div class="col-4">
                <p id="fechaPublicacionPropiedad" runat="server" style="margin-top: 35px; font-size: 25px">Publicado ...</p>
            </div>
        </div>

        <hr />

        <div class="row">

            <div class="col">
                <div>
                    <i class="fa-solid fa-house"></i>
                    <p id="cantAmbientes" runat="server"></p>
                </div>
            </div>
            <div class="col">
                <div>
                    <i class="fa-solid fa-ruler-combined"></i>
                    <p id="superficieTot" runat="server"></p>
                </div>
            </div>

            <div class="col">
                <div>
                    <i class="fa-solid fa-pen-ruler"></i>
                    <p id="superCub" runat="server"></p>
                </div>
            </div>

            <div id="divPatio" class="col" runat="server">
                <div>
                    <i class="fa-solid fa-tree"></i>
                    <p>Patio</p>
                </div>
            </div>

            <div class="col">
                <div>
                    <i class="fa-regular fa-clock"></i>
                    <p id="antigue" runat="server">Antiguedad</p>
                </div>
            </div>

        </div>

        <hr />
        <h2 id="tituloPropiedad" style="margin: 15px 0px 15px 0px" runat="server"></h2>
        <p id="descripcionPropiedad" class="card-text" runat="server"></p>
        <hr />

        <div class="form-group">

            <h3>Preguntas al anunciante</h3>
            <div class="row">
                <div class="col-8">

                    <div class="input-group mb-3">
                        <input type="text" class="form-control" placeholder="Hazle una pregunta al anunciante..." aria-label="Recipient's username" aria-describedby="button-addon2">
                        <button class="btn btn-dark" type="button" id="btnEnviarConsulta" OnClick="btnEnviarConsulta_Click">Button</button>
                    </div>

                </div>
         
            </div>

        </div>

    </div>



</asp:Content>
