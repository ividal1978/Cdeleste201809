<%@ Page Title="" Language="C#" MasterPageFile="~/Cdeleste.Master" AutoEventWireup="true" CodeBehind="ComoLlegar.aspx.cs" Inherits="WebApplication1.ComoLlegar" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="Scripts/jquery-3.0.0.min.js"></script>
    <script src="Scripts/bootstrap.min.js"></script>
    <link href="Scripts/Cdeleste.css" rel="stylesheet" />
    <link href="Scripts/jquery-ui.css" rel="stylesheet" type="text/css" />
    <script src="Scripts/jquery.js" type="text/javascript"></script>
    <script src="Scripts/jquery-ui.min.js" type="text/javascript"></script>
    <link href="Content/bootstrap.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />
    <br />
    <hr style="background-color: darkolivegreen; height: 15px;" />
    <hr style="background-color: darkgoldenrod; height: 4px;" />
    <h2 style="color: tan; font-family: 'Trebuchet MS'; text-shadow: 2px 2px 5px black;">&nbsp;&nbsp;&nbsp;Como Llegar</h2>
    <br />
    <br />
   
    <table style="color: saddlebrown !important;margin:1px;">
        <tr>
            <td style="width:2%"></td>
            <td style="width: 30%; vertical-align:top; padding:5px;" >
                     <div class="mapouter">
                            <div class="gmap_canvas card" >
                                <iframe width="100%" height="300px" id="gmap_canvas" src="https://maps.google.com/maps?q=La%20casona%20costa%20del%20este&t=&z=13&ie=UTF8&iwloc=&output=embed" frameborder="0" scrolling="no" marginheight="2" marginwidth="2"></iframe>
                                <a href="https://www.emojilib.com"></a></div>
                            <style>
                                .mapouter {
                                    position: relative;
                                    text-align: right;
                                    height: 300px;
                                    width: 100%;
                                    margin: 5px;
                                }

                                .gmap_canvas {
                                    overflow: hidden;
                                    background: none !important;
                                    height: 300px;
                                    width: 100%;
                                }
                            </style>
                        </div>
                 <div style="background-color:white; opacity:0.65; color:saddlebrown; vertical-align:top; border-radius:4px; padding:4px;">
        <p>Ubicado en el kilómetro 333 de la Ruta 11, entre los balnearios Mar del Tuyú y Aguas Verdes del Partido de La Costa,
        provincia de Buenos Aires, Argentina.</p>
        <p>Se puede llegar a Costa del Este en auto guiándose por un mapa carretero de la provincia. </p> 
        <p>En avión, hasta el aeropuerto de Santa Teresita (a 12 km de distancia) o el de Mar del Plata (a 186Km de distancia) desde allí tomar un remís, micro o taxi hasta el lugar,
        O en ómnibus hasta la terminal de Mar del Tuyú, desde allí tomar un taxi,  remís o micro local hacia Costa del Este.</p>
       <p> Las estacion de trenes mas cercana es la de Dolores a 136Km de distancia, desde alli debera trasbordar a un ómnubus / Autobus hasta Mar del Tuyú.</p>
       
    </div>
            </td>
            <td style="width: 54%; vertical-align:top;padding:5px;">
                <div class="accordion" id="accordionExample" style="background-color:tan; opacity:0.65; width: 98%; border-radius:4px;">
                    <div class="card">
                        <div class="card-header" id="headingOne">
                            <h2 class="mb-0">
                                <button class="btn btn-link" style="color: saddlebrown !important;" type="button" data-toggle="collapse" data-target="#collapseOne" aria-expanded="true" aria-controls="collapseOne">
                                    <i class="fas fa-car fa-2x"></i>  En Auto
                                </button>
                            </h2>
                        </div>

                        <div id="collapseOne" class="collapse show" aria-labelledby="headingOne" data-parent="#accordionExample">
                            <div class="card-body">
                                <i class="fas fa-car"></i>  En automóvil<br />
                                <p>Tomando como punto de partida la ciudad autónoma de buenos aires, las opciones las opciones mas utilizadas son por ruta 2 o por ruta 36.</p>
                                <p>Por Ruta 2: <br />
                                    Ruta 2 es una autovía de doble mano, este camino presenta dos peajes uno en autovía 2 y otro en ruta 11, a la altura del partido de dolores (Km 216 aproximadamente),
                                    debe tomar la desviación a la derecha para entrar en la ruta 63 (30 km aproximadamente), para luego llegar a Esquina de Crotto, allí empalmara con la ruta 11 , a unos 25km del empalme allí se encuentra la rotonda  para acceder a ruta 54, Tome la salida a ruta 11 (segunda salida) y hasta el kilómetro 333. 
                                    Este trayecto toma alrededor de 3H 50 min, son unos 330 kilómetros.</p>
                                <p>Por Ruta 36:<br />
                                    Ruta 36 es un ruta provincial la cual continua desde Avenida Calchaquí en el partido de Quilmes y
                                    unos 6 kilómetros después de la bajada de Autopista Buenos Aires la plata en la rotonda de Gutiérrez (Alpargatas)  en la localidad de El Pato,
                                    una vez que se encuentra sobre esta ruta, se continua por ella hasta llegar su final en la Ruta 11. Este camino presenta solo un peaje en ruta 11 y
                                    un recorrido de 350km aproximadamente. El tiempo de este recorrido ronda las 4h aproximadamente.
                                </p>




                            </div>
                        </div>
                    </div>
                    <div class="card">
                        <div class="card-header" id="headingTwo">
                            <h2 class="mb-0">
                                <button class="btn btn-link collapsed" style="color: saddlebrown !important;" type="button" data-toggle="collapse" data-target="#collapseTwo" aria-expanded="false" aria-controls="collapseTwo">
                                    <i class="fas fa-bus-alt fa-2x"></i>  En Micro / Autobus
                                </button>
                            </h2>
                        </div>
                        <div id="collapseTwo" class="collapse" aria-labelledby="headingTwo" data-parent="#accordionExample">
                            <div class="card-body">
                                <i class="fas fa-bus-alt"></i><p>En ómnibus  / autobús:</p>
                                <p>La estación de buses mas cercana en Mar del Tuyú ubicada en la calle 80 entre la calles 7 y 8, esta terminal opera las 24 hs, en ella hay servicio de taxis y remises. Desde allí llegan y salen micros para y hacia múltiples destinos.</p>
                                <p>El servicio de autobús colectivo zonal  (Zona Centro)  que llega al centro costa del este (camelias y Avenida 2) pasa por las cercanías de la terminal de micros de Mar del tuyú.
                                    <br /> Los horarios de los colectivos se pueden ver en la pagina https://www.cosyclastoninasltda.com.ar/</p>


                            </div>
                        </div>
                    </div>
                    <div class="card">
                        <div class="card-header" id="headingThree">
                            <h2 class="mb-0">
                                <button class="btn btn-link collapsed" style="color: saddlebrown !important;" type="button" data-toggle="collapse" data-target="#collapseThree" aria-expanded="false" aria-controls="collapseThree">
                                    <i class="fas fa-plane fa-2x"></i>  En Avión
                                </button>
                            </h2>
                        </div>
                        <div id="collapseThree" class="collapse" aria-labelledby="headingThree" data-parent="#accordionExample">
                            <div class="card-body">
                                <i class="fas fa-plane"></i>  An Avión:<br />
                                <p>El Aeródromo de Santa Teresita, se encuentra a 1.3Km al oeste de la ciudad de Santa Teresita, en la provincia de Buenos Aires. </p>
                                <p>Su dirección es Ruta 11, km 325 S/N (B7107) y sus coordenadas son latitud 36° 32' 32" S 056° 43' 18" W.</p>
                                <p>El aeródromo tiene su actividad pico durante los meses de verano pero funciona todo el año. Antiguamente durante la temporada de verano realizaba vuelos comerciales desde y hacia el Aeroparque Jorge Newbery de la Ciudad de Buenos Aires que acercaban a los turistas en 45 minutos.</p>


                            </div>
                        </div>
                    </div>
                    <div class="card">
                        <div class="card-header" id="headingThree">
                            <h2 class="mb-0">
                                <button class="btn btn-link collapsed" style="color: saddlebrown !important;" type="button" data-toggle="collapse" data-target="#collapseThree" aria-expanded="false" aria-controls="collapseThree">
                                    <i class="fas fa-train fa-2x"></i>  En Tren
                                </button>
                            </h2>
                        </div>
                        <div id="collapseThree" class="collapse" aria-labelledby="headingThree" data-parent="#accordionExample">
                            <div class="card-body">
                                <i class="fas fa-train"></i>  Tren:  Las estaciones mas cercanas a Costa del Este son las de Dolores (136Km) y Mar del Plata(196Km).
                                Desde cualquiera de estos lugares debera trasbordar a un ómnibus /Autobus hasta Mar del Tuyú y de alli en un taxi o remis hasta Costa del este.
                            </div>
                        </div>
                    </div>
                </div>
            </td>
            <td style="width: 2%"></td>
        </tr>
    </table>

</asp:Content>
