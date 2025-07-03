<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Perfiles.aspx.cs" Inherits="TPCuatrimestral_Inmobiliaria_Grupo6b.Perfiles" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.6/dist/css/bootstrap.min.css"/>
    <link rel="stylesheet" href="customize.css" />   <%-- linkea a la clase para el formato borde sombreado del contenedor del form  --%>

    <style>

        body::before {
            content: '';
            position: fixed;
            top: 0;
            left: 0;
            width: 100%;
            height: 100%;
            background-image: url('pictures/fondoDefault.png');
            background-size: cover;
            background-position: center;
            background-repeat: no-repeat;
            filter: blur(5px);
            z-index: -1;
        }

    </style>
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0/dist/js/bootstrap.bundle.min.js"></script>
</head>
<body>
    <form id="form1" runat="server">


        <div class="d-flex justify-content-center align-items-center" style="min-height: 100vh; padding: 10px;">
            <div align="center" class="container bg-light boxshadow col-12 col-md-10 col-lg-8 col-xl-6" style="border-radius: 15px; padding: 0; max-width: 800px;">
                
                <asp:Label ID="LabelMensaje" runat="server" Text="" Visible="false" CssClass="alert alert-danger"></asp:Label>

                <div>

                    <div class="position-relative text-white rounded-top d-flex justify-content-center align-items-center" style="padding: 15px; background-color: #121212;">
                        <h2 class="mb-0">Mi Perfil</h2>
                        <button type="button" class="btn-close btn-close-white position-absolute" aria-label="Cerrar" onclick="cerrarVentana()" style="top: 10px; right: 10px; filter: invert(1);"></button>
                    </div>
                    
                    <div class="px-3 px-md-4 py-2">

                        <div class="row mb-2">
                            <%--Se debe autocompletar el siguiente campo--%>
                            <div class="col-12 col-md-6 mb-2">
                                <label class="text-dark form-label" for="emailLabel">Correo Electronico</label>
                                <div class="input-group">
                                    <div class="input-group-prepend">
                                        <div class="input-group-text">@</div>
                                    </div>
                                    <asp:TextBox ID="TextBoxCorreo" runat="server" CssClass="form-control" placeholder="Ingrese su correo" ReadOnly="true">></asp:TextBox>
                                </div>
                            </div>

                            <%--Se debe autocompletar el siguiente campo--%>
                        <div class="col-12 col-md-6 mb-2">
                            <label class="text-dark form-label" for="TextBoxContra">Contraseña</label>
                            <div class="input-group">
                                <asp:TextBox ID="TextBoxContra" runat="server" TextMode="Password" CssClass="form-control"></asp:TextBox>
                                <button type="button" class="btn btn-outline-secondary" onclick="mostrarPassword()" id="mostrarBtn">Ver</button>
                            </div>
                        </div>
                        <asp:RegularExpressionValidator 
                            ID="revPassword" 
                            runat="server"
                            ControlToValidate="TextBoxContra"
                            ValidationExpression="^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)[^\s]{8,}$"
                            ErrorMessage="Requiere 8 caracteres, una mayúscula, una minúscula y un número"
                            Display="Dynamic"
                            CssClass="text-danger">
                        </asp:RegularExpressionValidator>
                        
                        <div class="row mb-2">
                            <div class="col-12 col-md-6 mb-2">
                                <label class="text-dark form-label" for="nombreLabel">Nombre</label>
                                <asp:TextBox ID="TextBoxNombre" runat="server" CssClass="form-control" placeholder="Ingrese su nombre"></asp:TextBox>
                            </div>
                            <div class="col-12 col-md-6 mb-2">
                                <label class="text-dark form-label" for="apellidoLabel">Apellido</label>
                                <asp:TextBox ID="TextBoxApellido" runat="server" CssClass="form-control" placeholder="Ingrese su apellido"></asp:TextBox>
                            </div>

                        </div>

                        <div class="row mb-2">
                            <div class="col-12 col-md-6 mb-2">
                                <label class="text-dark form-label" for="telefonoLabel">Teléfono</label>
                                <asp:TextBox ID="TextBoxTelefono" runat="server" CssClass="form-control" placeholder="Solo números sin espacios"></asp:TextBox>
                            </div>
                            <div class="col-12 col-md-6 mb-2">
                                <label class="text-dark form-label" for="direccionLabel">Dirección</label>
                                <asp:TextBox ID="TextBoxDireccion" runat="server" CssClass="form-control" placeholder="Calle y N°"></asp:TextBox>
                            </div>
                        </div>

                        <div class="row mb-2">
                            <div class="col-12 col-md-6 mb-2">
                                <label class="text-dark form-label" for="localidadLabel">Localidad</label>
                                <asp:TextBox ID="TextBoxLocalidad" runat="server" CssClass="form-control" placeholder="Localidad"></asp:TextBox>
                            </div>
                            <div class="col-12 col-md-6 mb-2">
                                <label class="text-dark form-label" for="provinciaLabel">Selecciona provincia</label>
                                <asp:DropDownList ID="DropDownListProvincia" runat="server" CssClass="form-control"></asp:DropDownList>
                            </div>
                        </div>
                        
                        <div class="row mb-3">
                            <div class="col-12 col-md-6 mb-2">
                                <label class="text-dark form-label" for="rolLabel">Tipo de usuario</label>
                                <asp:DropDownList ID="DropDownListRol" runat="server" CssClass="form-control"></asp:DropDownList>
                            </div>
                            <div class="col-12 col-md-6 d-flex align-items-end">
                                <asp:Button ID="ButtonActualizar" runat="server" Text="Actualizar" CssClass="btn btn-primary w-100" BackColor="#121212" OnClick="ButtonActualizar_Click"/>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </form>

    <%--Validacion para que si el usuario no esta logueado lo redireccione al login; en caso de estarlo, a Default--%>

    <% if (Session["usuario"] == null) { %>
        <script>
            document.addEventListener("keydown", function (event) {
                if (event.key === "Escape") {
                    location.replace("Login.aspx");
                }
            });
        </script>
    <% }
     else { %>
            <script type="text/javascript">
                function cerrarVentana() {
                    window.location.href = "Default.aspx";
                }
            </script>   

    <% } %>

    <%--Script para mostrar/ocultar la contraseña--%>

    <script>
        function mostrarPassword() {
            var passwordField = document.getElementById('<%= TextBoxContra.ClientID %>');
            var toggleBtn = document.getElementById('mostrarBtn');

            if (passwordField.type === 'password') {
                passwordField.type = 'text';
                toggleBtn.innerHTML = '***';
            } else {
                passwordField.type = 'password';
                toggleBtn.innerHTML = 'Ver';
            }
        }
    </script>

</body>
</html>
