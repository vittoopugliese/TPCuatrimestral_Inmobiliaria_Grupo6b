<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="PublicarInmueble.aspx.cs" Inherits="TPCuatrimestral_Inmobiliaria_Grupo6b.PublicarInmueble" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="container" style="margin-top: 4rem">

        <div class="text-center">
            <h1>Crear Publicación</h1>
        </div>

        <div class="card shadow-lg mx-auto w-75" style="margin-top: 25px; padding: 20px">
            <div class="card-body">

                <div class="row align-items-start">
                    <div class="col">
                        <div>
                            <label for="inputTipoOperacion" class="form-label" style="margin-top: 15px">Tipo de Operación</label>
                            <select id="TipoOperacion" class="form-select">
                                <option selected>Selecciona el tipo de operación</option>
                                <option>Venta</option>
                                <option>Alquiler</option>
                                <option>Temporada</option>
                            </select>
                        </div>

                        <div>
                            <label for="inputPropiedad" class="form-label" style="margin-top: 15px">Tipo de Propiedad</label>
                            <select id="TipoProp" class="form-select">
                                <option selected>Selecciona el tipo de propiedad</option>
                                <option>Casa</option>
                                <option>Departamento</option>
                                <option>PH</option>
                                <option>Local</option>
                            </select>
                        </div>

                        <div>
                            <label for="inputDireccion" class="form-label" style="margin-top: 15px">Dirección</label>
                            <input type="text" class="form-control" id="direccionSeleccionada" placeholder="Ingresá una dirección...">
                        </div>
                        <div>
                            <label for="inputAddress2" class="form-label" style="margin-top: 15px">Localidad</label>
                            <input type="text" class="form-control" id="localidadSeleccionada" placeholder="Ingresá la Localidad...">
                        </div>
                        <div>
                            <label for="inputProvincia" class="form-label" style="margin-top: 15px">Provincia</label>
                            <select id="idProvinciaSeleccionada" class="form-select">
                                <option selected>Buenos Aires</option>
                                <option>Córdoba</option>
                                <option>Mendoza</option>
                                <option>San Luis</option>
                                <option>San Juan</option>
                            </select>
                        </div>

                        <div>
                            <label for="inputAmbientes" class="form-label" style="margin-top: 15px">Ambientes</label>
                            <asp:TextBox ID="cantAmbientes" runat="server" CssClass="form-control"
                                placeholder="Cantidad de ambientes..." TextMode="Number" step="1"></asp:TextBox>
                        </div>

                        <div>
                            <label for="inputanosAntiguedad" class="form-label" style="margin-top: 15px">Años de antiguedad</label>
                            <asp:TextBox ID="anosAntiguedad" runat="server" CssClass="form-control"
                                placeholder="Años de antiguedad de la propiedad..." TextMode="Number" step="1"></asp:TextBox>
                        </div>

                    </div>

                    <div class="col">
                        <div>
                            <label for="inputTitulo" class="form-label" style="margin-top: 15px">Título</label>
                            <input type="text" class="form-control" id="titulo" placeholder="Título de su publicación...">
                        </div>

                        <div>
                            <label for="inputPrecio" class="form-label" style="margin-top: 15px">Precio</label>
                            <asp:TextBox ID="txtPrecio" runat="server" CssClass="form-control"
                                placeholder="Ej: 2500.50" TextMode="Number" step="0.01"></asp:TextBox>
                        </div>

                        <div>
                            <label for="inputTipoDueno" class="form-label" style="margin-top: 15px">Tipo de Dueño</label>
                            <select id="idTipoDueno" class="form-select">
                                <option>Inmobiliaria</option>
                                <option>Dueño Directo</option>
                            </select>
                        </div>

                        <div>
                            <label for="inputEmail" class="form-label" style="margin-top: 15px">e-mail</label>
                            <input type="email" class="form-control" id="email" placeholder="Ingrese su e-mail...">
                        </div>

                        <div>
                            <label for="inputWhatsapp" class="form-label" style="margin-top: 15px">Whatsapp</label>
                            <input type="tel" class="form-control" id="whatsapp" placeholder="Ingrese su Whatsapp...">
                        </div>

                        <div>
                            <label for="inputBanos" class="form-label" style="margin-top: 15px">Baños</label>
                            <asp:TextBox ID="cantBanos" runat="server" CssClass="form-control"
                                placeholder="Cantidad de baños..." TextMode="Number" step="1"></asp:TextBox>
                        </div>

                        <div>
                            <label for="inputDormitorios" class="form-label" style="margin-top: 15px">Dormitorios</label>
                            <asp:TextBox ID="cantDormitorios" runat="server" CssClass="form-control"
                                placeholder="Cantidad de Dormitorios..." TextMode="Number" step="1"></asp:TextBox>
                        </div>

                    </div>

                    <div class="row" style="margin-top: 35px">
                        <div class="col">
                            <div class="form-check">
                                <input class="form-check-input" type="checkbox" value="" id="balcon">
                                <label class="form-check-label" for="balc">
                                    Posee Balcón?
                                </label>
                            </div>
                        </div>
                        <div class="col">
                            <div class="form-check">
                                <input class="form-check-input" type="checkbox" value="" id="patio">
                                <label class="form-check-label" for="patioo">
                                    Posee Patio?
                                </label>
                            </div>
                        </div>
                        <div class="col">
                            <div class="form-check">
                                <input class="form-check-input" type="checkbox" value="" id="cochera">
                                <label class="form-check-label" for="coche">
                                    Posee Cochera?
                                </label>
                            </div>
                        </div>

                        <div class="col">
                            <div class="form-check">
                                <input class="form-check-input" type="checkbox" value="" id="credito">
                                <label class="form-check-label" for="credito">
                                    Apto Crédito?
                                </label>
                            </div>
                        </div>

                    </div>

                    <div class="row align-items-start">
                        <div class="col-1"></div>
                        <div class="col-10">
                            <div>
                                <label type="text" class="form-label" style="margin-top: 15px">Adjuntar Imágenes</label>
                                <div class="input-group">
                                    <asp:FileUpload ID="agregarImagen" CssClass="form-control" runat="server" AllowMultiple="true" />
                                </div>
                            </div>

                            <label for="inputDescripcion" class="form-label">Descripción</label>
                            <textarea class="form-control" id="descripcion" runat="server" placeholder="Ingrese la descripción..." rows="4"></textarea>

                        </div>
                        <div class="col-1"></div>
                    </div>

                    <div class="row align-items-start">
                        <div class="col"></div>
                        <div class="col">
                            <asp:Button Text="Guardar y Publicar" CssClass="btn btn-dark" ID="btnGuardarPublicacion" runat="server" OnClick="btnGuardarPublicacion_Click" Style="margin-top: 35px; width: 500px" />
                        </div>
                        <div class="col"></div>
                    </div>
                </div>
            </div>
        </div>
    </div>

</asp:Content>
