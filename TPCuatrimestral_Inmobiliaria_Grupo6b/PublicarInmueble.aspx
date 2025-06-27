<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="PublicarInmueble.aspx.cs" Inherits="TPCuatrimestral_Inmobiliaria_Grupo6b.PublicarInmueble" EnableEventValidation="false" %>

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
                            <label for="texttitulo" class="form-label">Título</label>
                            <asp:TextBox ID="texttitulo" runat="server"
                                CssClass="form-control"
                                placeholder="Ingrese título de su publicación..."
                                MaxLength="100">
                            </asp:TextBox>
                            <asp:RequiredFieldValidator ErrorMessage="El título es requerido" ControlToValidate="texttitulo" runat="server"></asp:RequiredFieldValidator>
                        </div>

                        <div>
                            <label for="selectTipoOperacion" class="form-label">Tipo de Operación</label>
                            <asp:DropDownList ID="ddlTipoOperacion" runat="server" CssClass="form-select">
                                <asp:ListItem Text="Seleccione el tipo Operación..." Value="" Selected="True" />
                                <asp:ListItem Text="Venta" Value="Venta" />
                                <asp:ListItem Text="Alquiler" Value="Alquiler" />
                                <asp:ListItem Text="Temporada" Value="Temporada" />
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="rfvTipoOperacion" runat="server"
                                ControlToValidate="ddlTipoOperacion"
                                InitialValue=""
                                ErrorMessage="Debe seleccionar un tipo de operación"
                                Display="Dynamic"
                                CssClass="text-danger">
                            </asp:RequiredFieldValidator>
                        </div>

                        <div>
                            <label for="selectTipoPropiedad" class="form-label">Tipo de Propiedad</label>
                            <asp:DropDownList ID="selectTipoPropiedad" runat="server" CssClass="form-select">
                                <asp:ListItem Text="Seleccione el tipo Propiedad..." Value="" Selected="True" />
                                <asp:ListItem Text="Casa" Value="Casa" />
                                <asp:ListItem Text="Departamento" Value="Departamento" />
                                <asp:ListItem Text="PH" Value="PH" />
                                <asp:ListItem Text="Local" Value="Local" />
                                <asp:ListItem Text="Quinta" Value="Quinta" />
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server"
                                ControlToValidate="selectTipoPropiedad"
                                InitialValue=""
                                ErrorMessage="Debe seleccionar un tipo de propiedad"
                                Display="Dynamic"
                                CssClass="text-danger">
                            </asp:RequiredFieldValidator>
                        </div>


                        <div>
                            <label for="inputDireccion" class="form-label">Dirección</label>
                            <asp:TextBox ID="inputDireccion" runat="server"
                                CssClass="form-control"
                                placeholder="Ingrese dirección..."
                                MaxLength="100">
                            </asp:TextBox>
                            <asp:RequiredFieldValidator ErrorMessage="La dirección es requerida" ControlToValidate="inputDireccion" runat="server"></asp:RequiredFieldValidator>
                        </div>


                        <div>
                            <label for="inputLocalidad" class="form-label">Localidad</label>
                            <asp:TextBox ID="inputLocalidad" runat="server"
                                CssClass="form-control"
                                placeholder="Ingresá Localidad..."
                                MaxLength="100">
                            </asp:TextBox>
                            <asp:RequiredFieldValidator ErrorMessage="La Localidad es requerida" ControlToValidate="inputLocalidad" runat="server"></asp:RequiredFieldValidator>
                        </div>

                        <div>

                            <div class="form-group">
                            </div>

                            <label for="selectProvincia" class="form-label">Provincia</label>


                            <asp:DropDownList ID="selectProvincia" runat="server" CssClass="form-control">
                                <asp:ListItem Text="Seleccione la Provincia..." Value="" Selected="True" />
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server"
                                ControlToValidate="selectProvincia"
                                InitialValue=""
                                ErrorMessage="Debe seleccionar una provincia"
                                Display="Dynamic"
                                CssClass="text-danger">
                            </asp:RequiredFieldValidator>
                        </div>

                        <div>
                            <label for="txtcantAmbientes" class="form-label">Cantidad de Ambientes</label>
                            <asp:TextBox ID="txtcantAmbientes" runat="server" CssClass="form-control"
                                placeholder="Ingrese cantidad de ambientes..." TextMode="Number" step="1"></asp:TextBox>

                            <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server"
                                ControlToValidate="txtcantAmbientes"
                                ErrorMessage="Debe completar la cantidad de ambientes"
                                Display="Dynamic"
                                CssClass="text-danger">
                            </asp:RequiredFieldValidator>

                            <asp:CompareValidator ID="CompareValidator6" runat="server"
                                ControlToValidate="txtcantAmbientes"
                                Operator="DataTypeCheck"
                                Type="Currency"
                                ErrorMessage="Debe ser un valor numérico válido"
                                Display="Dynamic"
                                CssClass="text-danger">
                            </asp:CompareValidator>

                            <asp:RangeValidator ID="RangeValidator6" runat="server"
                                ControlToValidate="txtcantAmbientes"
                                Type="Currency"
                                MinimumValue="0"
                                MaximumValue="999999999"
                                ErrorMessage="El valor debe ser mayor a 0 "
                                Display="Dynamic"
                                CssClass="text-danger">
                            </asp:RangeValidator>
                        </div>

                        <div>
                            <label for="textanosAntiguedad" class="form-label">Años de antiguedad</label>
                            <asp:TextBox ID="textanosAntiguedad" runat="server" CssClass="form-control"
                                placeholder="Ingrese cant. de años de antiguedad de la propiedad..." TextMode="Number" step="1"></asp:TextBox>

                            <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server"
                                ControlToValidate="textanosAntiguedad"
                                ErrorMessage="Debe completar los años de antiguedad"
                                Display="Dynamic"
                                CssClass="text-danger">
                            </asp:RequiredFieldValidator>

                            <asp:CompareValidator ID="CompareValidator7" runat="server"
                                ControlToValidate="textanosAntiguedad"
                                Operator="DataTypeCheck"
                                Type="Currency"
                                ErrorMessage="Debe ser un valor numérico válido"
                                Display="Dynamic"
                                CssClass="text-danger">
                            </asp:CompareValidator>

                            <asp:RangeValidator ID="RangeValidator7" runat="server"
                                ControlToValidate="textanosAntiguedad"
                                Type="Currency"
                                MinimumValue="0"
                                MaximumValue="999999999"
                                ErrorMessage="El valor debe ser mayor a 0 "
                                Display="Dynamic"
                                CssClass="text-danger">
                            </asp:RangeValidator>
                        </div>

                    </div>

                    <div class="col">

                        <div>
                            <label for="selectTipoMoneda" class="form-label">Tipo de Moneda</label>
                            <asp:DropDownList ID="selectTipoMoneda" runat="server" CssClass="form-select">
                                <asp:ListItem Text="Seleccione el tipo Moneda..." Value="" Selected="True" />
                                <asp:ListItem Text="US$" Value="US$" />
                                <asp:ListItem Text="$" Value="$" />
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server"
                                ControlToValidate="selectTipoMoneda"
                                InitialValue=""
                                ErrorMessage="Debe seleccionar un tipo de Moneda"
                                Display="Dynamic"
                                CssClass="text-danger">
                            </asp:RequiredFieldValidator>
                        </div>

                        <div>
                            <label for="txtPrecio" class="form-label">Precio</label>

                            <asp:TextBox ID="txtPrecio" runat="server" CssClass="form-control"
                                placeholder="Ingrese Precio..." TextMode="Number" step="0.01"></asp:TextBox>


                            <asp:RequiredFieldValidator ID="rfvPrecio" runat="server"
                                ControlToValidate="txtPrecio"
                                ErrorMessage="El precio es requerido"
                                Display="Dynamic"
                                CssClass="text-danger">
                            </asp:RequiredFieldValidator>

                            <asp:CompareValidator ID="cvPrecio" runat="server"
                                ControlToValidate="txtPrecio"
                                Operator="DataTypeCheck"
                                Type="Currency"
                                ErrorMessage="Debe ser un valor monetario válido"
                                Display="Dynamic"
                                CssClass="text-danger">
                            </asp:CompareValidator>

                            <asp:RangeValidator ID="rvPrecio" runat="server"
                                ControlToValidate="txtPrecio"
                                Type="Currency"
                                MinimumValue="0"
                                MaximumValue="999999999"
                                ErrorMessage="El precio debe ser mayor a 0"
                                Display="Dynamic"
                                CssClass="text-danger">
                            </asp:RangeValidator>
                        </div>


                        <div>
                            <label for="txtExpensas" class="form-label">Expensas</label>

                            <asp:TextBox ID="txtExpensas" runat="server" CssClass="form-control"
                                placeholder="Ingrese Expensas..." TextMode="Number" step="0.01"></asp:TextBox>


                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server"
                                ControlToValidate="txtExpensas"
                                ErrorMessage="Las expensas son requeridas"
                                Display="Dynamic"
                                CssClass="text-danger">
                            </asp:RequiredFieldValidator>

                            <asp:CompareValidator ID="CompareValidator1" runat="server"
                                ControlToValidate="txtExpensas"
                                Operator="DataTypeCheck"
                                Type="Currency"
                                ErrorMessage="Debe ser un valor monetario válido"
                                Display="Dynamic"
                                CssClass="text-danger">
                            </asp:CompareValidator>

                            <asp:RangeValidator ID="RangeValidator1" runat="server"
                                ControlToValidate="txtExpensas"
                                Type="Currency"
                                MinimumValue="0"
                                MaximumValue="999999999"
                                ErrorMessage="Las expensas deben ser mayor a 0 "
                                Display="Dynamic"
                                CssClass="text-danger">
                            </asp:RangeValidator>
                        </div>

                        <div>
                            <label for="txtCantBanos" class="form-label">Baños</label>
                            <asp:TextBox ID="txtCantBanos" runat="server" CssClass="form-control"
                                placeholder="Ingrese la cantidad de baños..." TextMode="Number" step="1"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server"
                                ControlToValidate="txtCantBanos"
                                ErrorMessage="Debe completar la cantidad de baños"
                                Display="Dynamic"
                                CssClass="text-danger">
                            </asp:RequiredFieldValidator>

                            <asp:CompareValidator ID="CompareValidator2" runat="server"
                                ControlToValidate="txtCantBanos"
                                Operator="DataTypeCheck"
                                Type="Currency"
                                ErrorMessage="Debe ser un valor numérico válido"
                                Display="Dynamic"
                                CssClass="text-danger">
                            </asp:CompareValidator>

                            <asp:RangeValidator ID="RangeValidator2" runat="server"
                                ControlToValidate="txtCantBanos"
                                Type="Currency"
                                MinimumValue="0"
                                MaximumValue="999999999"
                                ErrorMessage="La cantidad de baños debe ser mayor a 0 "
                                Display="Dynamic"
                                CssClass="text-danger">
                            </asp:RangeValidator>
                        </div>

                        <div>
                            <label for="inputCantDormitorios" class="form-label">Dormitorios</label>
                            <asp:TextBox ID="inputCantDormitorios" runat="server" CssClass="form-control"
                                placeholder="Ingrese la cantidad de Dormitorios..." TextMode="Number" step="1"></asp:TextBox>

                            <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server"
                                ControlToValidate="inputCantDormitorios"
                                ErrorMessage="Debe completar la cantidad de dormitorios"
                                Display="Dynamic"
                                CssClass="text-danger">
                            </asp:RequiredFieldValidator>

                            <asp:CompareValidator ID="CompareValidator3" runat="server"
                                ControlToValidate="inputCantDormitorios"
                                Operator="DataTypeCheck"
                                Type="Currency"
                                ErrorMessage="Debe ser un valor numérico válido"
                                Display="Dynamic"
                                CssClass="text-danger">
                            </asp:CompareValidator>

                            <asp:RangeValidator ID="RangeValidator3" runat="server"
                                ControlToValidate="inputCantDormitorios"
                                Type="Currency"
                                MinimumValue="0"
                                MaximumValue="999999999"
                                ErrorMessage="La cantidad de dormitorios debe ser mayor a 0 "
                                Display="Dynamic"
                                CssClass="text-danger">
                            </asp:RangeValidator>
                        </div>

                        <div>
                            <label for="SupCubierta" class="form-label">Superficie Cubierta (Mts2)</label>
                            <asp:TextBox ID="SupCubierta" runat="server" CssClass="form-control"
                                placeholder="Ingrese Mts2 de la Superficie cubierta..." TextMode="Number" step="1"></asp:TextBox>

                            <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server"
                                ControlToValidate="SupCubierta"
                                ErrorMessage="Debe completar la superficie cubierta"
                                Display="Dynamic"
                                CssClass="text-danger">
                            </asp:RequiredFieldValidator>

                            <asp:CompareValidator ID="CompareValidator4" runat="server"
                                ControlToValidate="SupCubierta"
                                Operator="DataTypeCheck"
                                Type="Currency"
                                ErrorMessage="Debe ser un valor numérico válido"
                                Display="Dynamic"
                                CssClass="text-danger">
                            </asp:CompareValidator>

                            <asp:RangeValidator ID="RangeValidator4" runat="server"
                                ControlToValidate="SupCubierta"
                                Type="Currency"
                                MinimumValue="0"
                                MaximumValue="999999999"
                                ErrorMessage="El valor debe ser mayor a 0 "
                                Display="Dynamic"
                                CssClass="text-danger">
                            </asp:RangeValidator>
                        </div>

                        <div>
                            <label for="SupTotal" class="form-label">Superficie Total (Mts2)</label>
                            <asp:TextBox ID="SupTotal" runat="server" CssClass="form-control"
                                placeholder="Ingrese Mts2 totales de la Propiedad..." TextMode="Number" step="1"></asp:TextBox>

                            <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server"
                                ControlToValidate="SupTotal"
                                ErrorMessage="Debe completar la superficie total"
                                Display="Dynamic"
                                CssClass="text-danger">
                            </asp:RequiredFieldValidator>

                            <asp:CompareValidator ID="CompareValidator5" runat="server"
                                ControlToValidate="SupTotal"
                                Operator="DataTypeCheck"
                                Type="Currency"
                                ErrorMessage="Debe ser un valor numérico válido"
                                Display="Dynamic"
                                CssClass="text-danger">
                            </asp:CompareValidator>

                            <asp:RangeValidator ID="RangeValidator5" runat="server"
                                ControlToValidate="SupTotal"
                                Type="Currency"
                                MinimumValue="0"
                                MaximumValue="999999999"
                                ErrorMessage="El valor debe ser mayor a 0 "
                                Display="Dynamic"
                                CssClass="text-danger">
                            </asp:RangeValidator>
                        </div>

                        <div>
                            <label for="txtWhatsapp" class="form-label">Whatsapp</label>

                            <asp:TextBox ID="txtWhatsapp" runat="server"
                                CssClass="form-control"
                                placeholder="Ingrese el número de whatsapp..."
                                MaxLength="100">
                            </asp:TextBox>
                            <asp:RequiredFieldValidator ErrorMessage="El whatsapp es requerido" ControlToValidate="txtWhatsapp" runat="server"></asp:RequiredFieldValidator>

                        </div>

                        <div>

                            <label for="inputEmail" class="form-label">e-mail</label>
                            <asp:TextBox ID="inputEmail" runat="server"
                                CssClass="form-control"
                                placeholder="Ingrese su e-mail..."
                                TextMode="Email"
                                MaxLength="100">
                            </asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvEmail" runat="server"
                                ControlToValidate="inputEmail"
                                ErrorMessage="El email es requerido"
                                Display="Dynamic"
                                CssClass="text-danger">
                            </asp:RequiredFieldValidator>
                            <!-- Validador de formato de email -->
                            <asp:RegularExpressionValidator ID="revEmail" runat="server"
                                ControlToValidate="inputEmail"
                                ValidationExpression="^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$"
                                ErrorMessage="Ingrese un email válido (ej: usuario@dominio.com)"
                                Display="Dynamic"
                                CssClass="text-danger">
                            </asp:RegularExpressionValidator>
                        </div>
                    </div>

                    <div class="row">
                        <div class="col">
                            <div class="form-check">
                                <input class="form-check-input" type="checkbox" value="" id="inputBalcon" runat="server">
                                <label class="form-check-label" for="balc">
                                    Balcón
                               
                                </label>
                            </div>
                        </div>
                        <div class="col">
                            <div class="form-check">
                                <input class="form-check-input" type="checkbox" value="" id="inputPatio" runat="server">
                                <label class="form-check-label" for="patioo">
                                    Patio
                               
                                </label>
                            </div>
                        </div>
                        <div class="col">
                            <div class="form-check">
                                <input class="form-check-input" type="checkbox" value="" id="inputCochera" runat="server">
                                <label class="form-check-label" for="coche">
                                    Cochera
                               
                                </label>
                            </div>
                        </div>

                        <div class="col">
                            <div class="form-check">
                                <input class="form-check-input" type="checkbox" value="" id="inputCredito" runat="server">
                                <label class="form-check-label" for="inputCredito">
                                    Crédito
                               
                                </label>
                            </div>
                        </div>

                    </div>

                    <div class="form-group">
                        <label for="txtDescripcion" class="form-label">Descripción</label>
                        <asp:TextBox ID="txtDescripcion" runat="server"
                            CssClass="form-control"
                            TextMode="MultiLine"
                            Rows="4"
                            placeholder="Ingrese la descripción de la propiedad..."
                            MaxLength="1000">
                        </asp:TextBox>

                        <asp:RequiredFieldValidator ErrorMessage="La descripción es requerida" ControlToValidate="txtDescripcion" runat="server"></asp:RequiredFieldValidator>

                    </div>

                    <div class="row mt-3">
                        <h5>Imágenes actuales</h5>
                        <asp:Repeater ID="rptImagenes" runat="server">
                            <ItemTemplate>
                                <div class="col-md-3 mb-3">
                                    <div class="card">
                                        <img src='<%# "~/Images/" + Container.DataItem %>' runat="server" class="card-img-top" style="height: 150px; object-fit: cover;" />
                                        <div class="card-body text-center">
                                            <asp:LinkButton runat="server" CssClass="btn btn-danger btn-sm"
                                                CommandArgument='<%# Container.DataItem %>'
                                                OnCommand="EliminarImagen_Command"
                                                Text="Eliminar" />
                                        </div>
                                    </div>
                                </div>
                            </ItemTemplate>
                        </asp:Repeater>
                    </div>

                    <div class="row align-items-start">
                        <div class="col-1"></div>
                        <div class="col-10">
                            <div>
                                <label type="text" class="form-label">Adjuntar Imágenes</label>
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
                            <asp:Button Text="Guardar y Publicar" CssClass="btn btn-dark" ID="btnGuardarPublicacion" runat="server" OnClick="btnGuardarPublicacion_Click" Style="margin-top: 35px; width: 500px;" />
                        </div>
                        <div class="col"></div>
                    </div>

                    <div class="row align-items-start">
                        <div class="col"></div>

                        <div class="col">
                            <asp:Button Text="Volver" CssClass="btn btn-dark" ID="btnVolver" runat="server" OnClick="btnVolver_Click" Style="margin-top: 35px; width: 300px;" />
                        </div>
                        <div class="col"></div>


                    </div>

                </div>
            </div>
        </div>
    </div>



</asp:Content>
