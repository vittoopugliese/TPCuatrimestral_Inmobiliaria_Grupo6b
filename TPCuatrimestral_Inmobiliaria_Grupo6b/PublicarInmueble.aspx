<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="PublicarInmueble.aspx.cs" Inherits="TPCuatrimestral_Inmobiliaria_Grupo6b.PublicarInmueble" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="container" style="margin-top: 4rem">
        <div class="card shadow-lg mx-auto w-75" style="margin-top: 25px; background-color: #f0f0f0">
            <!-- Nuevo card-header con fondo oscuro y texto blanco -->
            <div class="card-header bg-dark text-white py-3">
                <h5 class="card-title mb-0">Crear Publicación</h5>
            </div>
             
            <div class="card-body" style="padding: 20px">
                <!-- Resto de tu formulario (se mantiene igual) -->
                <div class="row align-items-start">
                    <div class="col">
                        <div>
                            <label for="TipoOperacion" class="form-label" style="margin-top: 15px">Tipo de Operación</label>
                            <select id="selectTipoOperacion" class="form-select" runat="server">
                                <option selected disabled value="">Seleccione el tipo Operación...</option>
                                <option>Venta</option>
                                <option>Alquiler</option>
                                <option>Temporada</option>
                            </select>
                        </div>
                        

                        <div>
                            <label for="TipoPropiedad" class="form-label" style="margin-top: 15px">Tipo de Propiedad</label>
                            <select id="selectTipoPropiedad" class="form-select" runat="server">
                                <option selected disabled value="">Seleccione el tipo Propiedad...</option>
                                <option>Casa</option>
                                <option>Departamento</option>
                                <option>PH</option>
                                <option>Local</option>
                            </select>
                        </div>

                        <div>
                            <label for="inputDireccion" class="form-label" style="margin-top: 15px">Dirección</label>
                            <input type="text" class="form-control" id="inputdireccion" placeholder="Ingrese dirección..." runat="server">
                        </div>
                        <div>
                            <label for="inputLocalidad" class="form-label" style="margin-top: 15px">Localidad</label>
                            <input type="text" class="form-control" id="inputlocalidad" placeholder="Ingresá Localidad..." runat="server">
                        </div>
                        <div>
                            <label for="inputProvincia" class="form-label" style="margin-top: 15px">Provincia</label>
                            <select id="selectProvincia" class="form-select" runat="server">
                                <option selected disabled value="">Seleccione Provincia...</option>
                                <option>Córdoba</option>
                                <option>Mendoza</option>
                                <option>San Luis</option>
                                <option>San Juan</option>
                            </select>
                        </div>

                        <div>
                            <label for="inputCantAmbientes" class="form-label" style="margin-top: 15px">Cantidad de Ambientes</label>
                            <asp:TextBox ID="txtcantAmbientes" runat="server" CssClass="form-control"
                                placeholder="Ingrese cantidad de ambientes..." TextMode="Number" step="1"></asp:TextBox>
                        </div>

                        <div>
                            <label for="inputanosAntiguedad" class="form-label" style="margin-top: 15px">Años de antiguedad</label>
                            <asp:TextBox ID="textanosAntiguedad" runat="server" CssClass="form-control"
                                placeholder="Ingrese cant. de años de antiguedad de la propiedad..." TextMode="Number" step="1"></asp:TextBox>
                        </div>

                    </div>

                    <div class="col">
                        <div>
                            <label for="inputTitulo" class="form-label" style="margin-top: 15px">Título</label>
                            <input type="text" class="form-control" id="texttitulo" placeholder="Ingrese título su publicación..." runat="server">
                        </div>

                        <div>
                            <label for="inputPrecio" class="form-label" style="margin-top: 15px">Precio</label>
                            <asp:TextBox ID="txtPrecio" runat="server" CssClass="form-control"
                                placeholder="Ingrese precio de la propiedad, ej: $250.000" TextMode="Number" step="1"></asp:TextBox>
                        </div>

                        <div>
                            <label for="inputTipoDueno" class="form-label" style="margin-top: 15px">Tipo de Propietario</label>
                            <select id="txtTipoDueno" class="form-select" runat="server">
                                <option selected disabled value="">Seleccione el Tipo de Propietario...</option>
                                <option>Inmobiliaria</option>
                                <option>Dueño Directo</option>
                                <option>Gestor</option>
                            </select>
                        </div>

                        <div>
                            <label for="inputEmail" class="form-label" style="margin-top: 15px">e-mail</label>
                            <input type="email" class="form-control" id="inputEmail" placeholder="Ingrese su e-mail..." runat="server">
                        </div>

                        <div>
                            <label for="Whatsapp" class="form-label" style="margin-top: 15px">Whatsapp</label>
                            <asp:TextBox ID="txtWhatsapp" runat="server" CssClass="form-control" placeholder="Ingrese su número de whastapp..." TextMode="number" step="1"></asp:TextBox>
                        </div>

                        <div>
                            <label for="inputBanos" class="form-label" style="margin-top: 15px">Baños</label>
                            <asp:TextBox ID="txtCantBanos" runat="server" CssClass="form-control"
                                placeholder="Ingrese la cantidad de baños..." TextMode="Number" step="1"></asp:TextBox>
                        </div>

                        <div>
                            <label for="inputDormitorios" class="form-label" style="margin-top: 15px">Dormitorios</label>
                            <asp:TextBox ID="inputCantDormitorios" runat="server" CssClass="form-control"
                                placeholder="Ingrese la cantidad de Dormitorios..." TextMode="Number" step="1"></asp:TextBox>
                        </div>

                    </div>

                    <div class="row" style="margin-top: 35px">
                        <div class="col">
                            <div class="form-check">
                                <input class="form-check-input" type="checkbox" value="" id="inputBalcon" runat="server">
                                <label class="form-check-label" for="balc">
                                    Posee Balcón?
                                </label>
                            </div>
                        </div>
                        <div class="col">
                            <div class="form-check">
                                <input class="form-check-input" type="checkbox" value="" id="inputPatio" runat="server">
                                <label class="form-check-label" for="patioo">
                                    Posee Patio?
                                </label>
                            </div>
                        </div>
                        <div class="col">
                            <div class="form-check">
                                <input class="form-check-input" type="checkbox" value="" id="inputCochera" runat="server">
                                <label class="form-check-label" for="coche">
                                    Posee Cochera?
                                </label>
                            </div>
                        </div>

                        <div class="col">
                            <div class="form-check">
                                <input class="form-check-input" type="checkbox" value="" id="inputCredito" runat="server">
                                <label class="form-check-label" for="credito">
                                    Apto Crédito?
                                </label>
                            </div>
                        </div>

                    </div>

                    <label for="inputDescripcion" class="form-label" style="margin-top: 20px">Descripción</label>
                    <textarea class="form-control" id="txtDescripcion" runat="server" placeholder="Ingrese la descripción de la propiedad..." rows="4"></textarea>


                    <div class="row align-items-start">
                        <div class="col-1"></div>
                        <div class="col-10">
                            <div>
                                <label type="text" class="form-label" style="margin-top: 15px">Adjuntar Imágenes</label>
                                <div class="input-group">
                                    <asp:FileUpload ID="agregarImagen" CssClass="form-control btn btn-dark" runat="server" AllowMultiple="true" />
                                </div>
                            </div>

                        </div>
                        <div class="col-1"></div>
                    </div>

                    <div class="row align-items-start">
                        <div class="col"></div>
                        <div class="col">
                            <asp:Button Text="Guardar y Publicar" CssClass="btn btn-dark" ID="btnGuardarPublicacion" runat="server" OnClick="btnGuardarPublicacion_Click" Style="margin-top: 35px; width: 500px; " />
                        </div>
                        <div class="col"></div>
                    </div>
                </div>
            </div>
        </div>
    </div>

</asp:Content>
