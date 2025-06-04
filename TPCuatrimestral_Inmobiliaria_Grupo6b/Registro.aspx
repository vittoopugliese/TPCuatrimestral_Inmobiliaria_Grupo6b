<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Registro.aspx.cs" Inherits="TPCuatrimestral_Inmobiliaria_Grupo6b.Registro" %>

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

</head>
<body>
    <form id="form1" runat="server">


        <div class="d-flex justify-content-center align-items-center" style="min-height: 100vh; padding: 10px;">
            <div align="center" class="container bg-light boxshadow col-12 col-md-10 col-lg-8 col-xl-6" style="border-radius: 15px; padding: 0; max-width: 800px;">
                
                <div>
                    <div class="text-white d-flex align-items-center justify-content-center" style="border-top-left-radius: 15px; border-top-right-radius: 15px; padding: 10px; margin: 0; background-color: #121212;">
                        <h5 class="mb-0">Registro de usuario</h5>
                    </div>
                    
                    <div class="px-3 px-md-4 py-2">

                        <div class="row mb-2">
                            <div class="col-12 col-md-6 mb-2">
                                <label class="text-dark form-label" for="emailLabel">Correo Electronico</label>
                                <div class="input-group">
                                    <div class="input-group-prepend">
                                        <div class="input-group-text">@</div>
                                    </div>
                                    <asp:TextBox ID="TextBoxCorreo" runat="server" CssClass="form-control" placeholder="Ingrese su correo"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-12 col-md-6 mb-2">
                                <label class="text-dark form-label" for="contrasenaLabel">Contraseña</label>
                                <asp:TextBox ID="TextBoxContra" runat="server" CssClass="form-control" placeholder="Alfanúmerico todo minúscula"></asp:TextBox>
                            </div>
                        </div>
                        
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
                                <asp:Button ID="ButtonRegistrar" runat="server" Text="Registrar" CssClass="btn btn-primary w-100" BackColor="#121212" />
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </form>

        <script>
            document.addEventListener("keydown", function (event) {
                if (event.key === "Escape") {
                    location.replace("Login.aspx");
                }
            });
        </script>

</body>
</html>