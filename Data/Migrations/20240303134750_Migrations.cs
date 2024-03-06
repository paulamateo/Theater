﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Theater.Data.Migrations
{
    public partial class Migrations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Shows",
                columns: table => new
                {
                    ShowId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Author = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Director = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Genre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Age = table.Column<int>(type: "int", nullable: false),
                    Poster = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Banner = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Scene = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Overview = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Shows", x => x.ShowId);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserLastname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsAdmin = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "Sessions",
                columns: table => new
                {
                    SessionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateSession = table.Column<DateTime>(type: "datetime2", nullable: false),
                    QuantitySeats = table.Column<int>(type: "int", nullable: false),
                    ShowId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sessions", x => x.SessionId);
                    table.ForeignKey(
                        name: "FK_Sessions_Shows_ShowId",
                        column: x => x.ShowId,
                        principalTable: "Shows",
                        principalColumn: "ShowId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Reservations",
                columns: table => new
                {
                    ReservationId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TotalPrice = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    SessionId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reservations", x => x.ReservationId);
                    table.ForeignKey(
                        name: "FK_Reservations_Sessions_SessionId",
                        column: x => x.SessionId,
                        principalTable: "Sessions",
                        principalColumn: "SessionId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Reservations_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Seats",
                columns: table => new
                {
                    SeatId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsDisponible = table.Column<bool>(type: "bit", nullable: false),
                    ReservationId = table.Column<int>(type: "int", nullable: true),
                    SessionId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Seats", x => x.SeatId);
                    table.ForeignKey(
                        name: "FK_Seats_Reservations_ReservationId",
                        column: x => x.ReservationId,
                        principalTable: "Reservations",
                        principalColumn: "ReservationId");
                    table.ForeignKey(
                        name: "FK_Seats_Sessions_SessionId",
                        column: x => x.SessionId,
                        principalTable: "Sessions",
                        principalColumn: "SessionId");
                });

            migrationBuilder.InsertData(
                table: "Shows",
                columns: new[] { "ShowId", "Age", "Author", "Banner", "Director", "Genre", "Overview", "Poster", "Scene", "Title" },
                values: new object[,]
                {
                    { 1, 18, "Gaston Leroux", "n", "Sara García", "Musical", "En la majestuosa Ópera Garnier de París, 'El Fantasma de la Ópera' despliega una intrigante trama donde la talentosa soprano Christine Daaé se encuentra en medio de un apasionante triángulo amoroso. Entre el enigmático Fantasma, un genio musical desfigurado que la guía desde las sombras, y el apasionado vizconde Raoul de Chagny, la historia explora los límites entre la belleza y la fealdad, la obsesión y la devoción, creando una atmósfera fascinante en el esplendor de la ópera parisina. La narrativa se teje con emociones intensas, llevando al espectador a las profundidades de la pasión humana, la tragedia y el misterio en un escenario donde la música y el amor convergen de manera inolvidable.", "n", "n", "El Fantasma de la Ópera" },
                    { 2, 16, "William Shakespeare", "n", "Carlos Montoya", "Tragedia", "En los páramos de Escocia, 'Macbeth' despliega una trama de ambición y traición. La obra sigue al valiente guerrero Macbeth, quien, tras un encuentro con tres brujas proféticas, es tentado por el deseo de poder. Instigado por su esposa, Lady Macbeth, Macbeth asesina al rey Duncan y se sumerge en un oscuro camino de conspiración y asesinato para asegurar su reinado. La historia se sumerge en la psique de Macbeth, donde la ambición y la culpa chocan de manera intensa. Las consecuencias de sus acciones desatan una espiral de violencia y desconfianza, llevándolo a un destino trágico. 'Macbeth' explora las complejidades del poder, la moral y la corrupción en un oscuro escenario donde las decisiones desencadenan consecuencias irreversibles.", "n", "n", "Macbeth" },
                    { 3, 14, "William Shakespeare", "n", "Ana Sánchez", "Musical", "En el intrigante escenario de la corte danesa, 'Hamlet' despliega una trama de venganza y dilemas morales. El príncipe Hamlet, sumido en la pena por la muerte de su padre, el rey, descubre un perturbador secreto: su tío Claudio ha usurpado el trono y se ha casado con la madre de Hamlet, la reina Gertrudis. Atormentado por la revelación y la sombra del fantasma de su padre, Hamlet se ve envuelto en una espiral de intriga y desconfianza. La obra explora la compleja psicología de Hamlet mientras navega por las tensiones familiares y la búsqueda de justicia. Las dudas, las reflexiones filosóficas y la tragedia se entrelazan en esta historia llena de engaños y traiciones. 'Hamlet' lleva al espectador a través de un viaje emocional y reflexivo, explorando la naturaleza de la venganza y las consecuencias de las decisiones tomadas en un entorno palaciego cargado de intrigas y secretos.", "n", "n", "Hamlet" },
                    { 4, 16, "Andrew Lloyd Webber", "n", "Daniela Méndez", "Ballet", "En un encantador escenario invernal, 'El Cascanueces' sumerge al público en un mundo de fantasía y magia. La historia comienza durante una celebración navideña en la casa de los Stahlbaum, donde la joven Clara recibe un regalo especial, un cascanueces de madera. En medio de la noche, el Cascanueces cobra vida, y Clara se embarca en una extraordinaria aventura a través de reinos mágicos. La trama se desarrolla en el Reino de los Dulces, gobernado por la Hada de Azúcar, y enfrenta a Clara y al Cascanueces contra el malvado Rey Ratón. A medida que la historia se desenvuelve, se despliega un deslumbrante despliegue de danzas y personajes, desde los exquisitos Copos de Nieve hasta los encantadores Azúcares y Flores. 'El Cascanueces' captura la imaginación con su encanto, transportando al público a un mundo de sueños donde la magia y la danza se entrelazan en una celebración inolvidable de la fantasía navideña.", "n", "n", "El Cascanueces" },
                    { 5, 18, "Dante Alighieri", "n", "Luis Rosa", "Drama", "En los oscuros confines del Infierno hasta las alturas celestiales del Paraíso, 'La Divina Comedia' de Dante Alighieri es un viaje épico a través de los reinos de ultratumba. La trama sigue al poeta Dante, quien se encuentra perdido en un bosque oscuro y es guiado por el espíritu de Virgilio a través de los nueve círculos del Infierno. En este viaje, Dante encuentra a figuras históricas y mitológicas, cada una castigada por sus pecados de acuerdo con la justicia divina. A medida que Dante asciende desde el Infierno, atraviesa el monte del Purgatorio, donde las almas buscan la redención. Finalmente, alcanza el Paraíso, donde su amada Beatriz lo conduce a través de los cielos, revelando los misterios divinos. 'La Divina Comedia' explora la teología, la moral y la redención, ofreciendo una visión poética y filosófica de la vida humana y la relación con lo divino en un viaje que trasciende los límites terrenales hacia las profundidades del alma y la eternidad.", "n", "n", "Divina Comedia" },
                    { 6, 16, "Sófocles", "n", "Rafael López", "Tragedia", "En la ciudad de Tebas, 'Edipo Rey' de Sófocles narra una tragedia impactante que sigue la vida del rey Edipo. La historia comienza con la ciudad asolada por la peste, y Edipo, decidido a encontrar la causa de esta calamidad, inicia una investigación que revela oscuros secretos. Edipo descubre que es el culpable involuntario del incesto y el parricidio, eventos predichos por el oráculo mucho tiempo atrás. El protagonista, ignorante de su linaje, se enfrenta a la dolorosa verdad de su destino trágico. La obra explora temas como el libre albedrío, el destino y la ceguera frente a la verdad, llevando a la audiencia a través de una emocionante travesía psicológica mientras Edipo lucha contra las inevitables consecuencias de su propio desconocimiento y las decisiones de aquellos que lo precedieron.", "n", "n", "Edipo Rey" },
                    { 7, 16, "William Shakespeare", "n", "Marta Váldez", "Tragedia", "En la vibrante ciudad de Verona, 'Romeo y Julieta' de William Shakespeare relata un apasionado y trágico romance entre dos jóvenes de familias enemistadas, los Montesco y los Capuleto. La historia se inicia con un encuentro fortuito en una fiesta, donde los jóvenes enamorados, Romeo y Julieta, se ven irresistiblemente atraídos el uno al otro. A pesar de las tensiones familiares, deciden casarse en secreto, desencadenando una serie de eventos fatídicos. Los desafíos que enfrentan por el odio ancestral entre sus casas culminan en un desenlace desgarrador. 'Romeo y Julieta' explora la intensidad del amor juvenil, la imprudencia de la pasión y las consecuencias trágicas que pueden surgir cuando el destino se interpone en el camino del amor verdadero. La obra de Shakespeare sigue siendo un testamento atemporal del poder del amor y las trágicas consecuencias de la enemistad desmedida.", "n", "n", "Romeo y Julieta" },
                    { 8, 14, "Alan Jay Lerner", "n", "Domingo Gómez", "Musical", "En el mágico reino de Camelot, la obra 'Camelot' de Alan Jay Lerner transporta a los espectadores a un mundo de mitos y nobleza. La trama sigue al legendario Rey Arturo, la reina Ginebra y el apasionado caballero Lanzarote, explorando la fundación utópica de Camelot y los desafíos que surgen cuando un triángulo amoroso amenaza con socavar los nobles ideales del reino. Con una emotiva banda sonora que resalta los momentos de amor y traición, 'Camelot' se erige como un clásico teatral que captura la eterna lucha entre el deber y el deseo, ofreciendo una mirada atemporal a la fragilidad de los ideales frente a las complejidades del amor y la moral.", "n", "n", "Camelot" },
                    { 9, 16, "Molière", "n", "José Luis Alonso", "Comedia", "En el animado escenario de la comedia clásica 'Las Preciosas Ridículas' de Molière, la trama se desenvuelve en la París del siglo XVII, ofreciendo una sátira ingeniosa sobre la afectación y la superficialidad de la sociedad de la época. La obra sigue a las encantadoras pero vanidosas señoritas Magdelón y Cathos, quienes, en su afán por ascender socialmente, se ven envueltas en enredos cómicos. La trama se desata cuando las preciosas creen estar cortejando a dos hombres de alta alcurnia, sin percatarse de la farsa que los caballeros y sus criados han orquestado. Con agudo ingenio y diálogos mordaces, Molière pinta un retrato humorístico de la afectación y la hipocresía social. 'Las Preciosas Ridículas' se destaca por su agudeza satírica, abordando con destreza las contradicciones humanas mientras ofrece una mirada entretenida y atemporal a las idiosincrasias de la sociedad.", "n", "n", "Las Preciosas Ridículas" },
                    { 10, 12, "Fernando de Rojas", "n", "Macarena Gil", "Drama", "En el oscuro escenario medieval de 'La Celestina', la obra maestra trágica de Fernando de Rojas, se despliega un drama que escudriña las complejidades de la pasión, la codicia y el poder. La trama se centra en la historia de Calisto y Melibea, dos jóvenes amantes cuya relación prohibida desencadena una serie de eventos desgarradores. La figura de la astuta Celestina, una alcahueta manipuladora, emerge como el catalizador de la tragedia al utilizar sus artimañas para propiciar encuentros clandestinos. Rojas examina las oscuras facetas del deseo humano y la vulnerabilidad de la moralidad en una sociedad corrupta. Con diálogos intensos y personajes complejos, 'La Celestina' se erige como una obra inmortal que desentraña las complejidades de la naturaleza humana, destacando la fragilidad de las relaciones y los peligros que surgen cuando la pasión se desborda.", "n", "n", "La Celestina" },
                    { 11, 14, "Oscar Wilde", "n", "Pedro Jiménez", "Comedia", "En el elegante mundo de la alta sociedad victoriana, 'Un Marido Ideal' de Oscar Wilde despliega una comedia satírica que revela las intrigas y secretos ocultos detrás de las fachadas de respetabilidad. La trama sigue al político Sir Robert Chiltern, cuyo prestigio se ve amenazado cuando un oscuro secreto de su pasado es descubierto por la intrigante Mrs. Cheveley. Con su característico ingenio, Wilde teje una trama repleta de diálogos agudos y situaciones cómicas mientras examina la hipocresía y las dobles morales de la sociedad de la época. 'Un Marido Ideal' ofrece una mirada satírica a la moralidad, la corrupción y la fragilidad de las reputaciones en una sociedad obsesionada por las apariencias. Con personajes inolvidables y giros inesperados, la obra sigue siendo una comedia atemporal que invita a la reflexión sobre la naturaleza humana y la moralidad.", "n", "n", "Un Marido Ideal" },
                    { 12, 10, "Agatha Christie", "n", "María García", "Misterio", "En el intrigante escenario de 'La Ratonera' de Agatha Christie, los espectadores se sumergen en un misterio envolvente que se desarrolla en el pintoresco Molino Monkswell. La historia comienza cuando un grupo ecléctico de personajes se ve atrapado en una posada durante una tormenta de nieve, desencadenando una serie de eventos que revelan oscuros secretos y conexiones sorprendentes. La trama se teje con maestría, dejando que la sospecha recaiga sobre cada personaje mientras el misterio se desenvuelve. Con giros inesperados y un ingenioso desenlace, Agatha Christie cautiva a la audiencia con su habilidad para mantener en vilo hasta el último momento. 'La Ratonera' se erige como un clásico del suspense, explorando la complejidad de la naturaleza humana y la imprevisibilidad de los secretos bien guardados, dejando a los espectadores absortos en la intriga y el suspenso hasta la última revelación.", "n", "n", "La Ratonera" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "Email", "IsAdmin", "Password", "PhoneNumber", "UserLastname", "UserName" },
                values: new object[] { 1, "a26619@svalero.com", true, "1234", "123456789", "Mateo", "Paula" });

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_SessionId",
                table: "Reservations",
                column: "SessionId");

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_UserId",
                table: "Reservations",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Seats_ReservationId",
                table: "Seats",
                column: "ReservationId");

            migrationBuilder.CreateIndex(
                name: "IX_Seats_SessionId",
                table: "Seats",
                column: "SessionId");

            migrationBuilder.CreateIndex(
                name: "IX_Sessions_ShowId",
                table: "Sessions",
                column: "ShowId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Seats");

            migrationBuilder.DropTable(
                name: "Reservations");

            migrationBuilder.DropTable(
                name: "Sessions");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Shows");
        }
    }
}