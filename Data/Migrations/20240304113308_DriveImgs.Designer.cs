﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Theater.Data;

#nullable disable

namespace Theater.Data.Migrations
{
    [DbContext(typeof(TheaterContext))]
    [Migration("20240304113308_DriveImgs")]
    partial class DriveImgs
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Theater.Models.Reservation", b =>
                {
                    b.Property<int>("ReservationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ReservationId"), 1L, 1);

                    b.Property<int>("SessionId")
                        .HasColumnType("int");

                    b.Property<int>("TotalPrice")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("ReservationId");

                    b.HasIndex("SessionId");

                    b.HasIndex("UserId");

                    b.ToTable("Reservations");
                });

            modelBuilder.Entity("Theater.Models.Seat", b =>
                {
                    b.Property<int>("SeatId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SeatId"), 1L, 1);

                    b.Property<bool>("IsDisponible")
                        .HasColumnType("bit");

                    b.Property<int?>("ReservationId")
                        .HasColumnType("int");

                    b.Property<int?>("SessionId")
                        .HasColumnType("int");

                    b.HasKey("SeatId");

                    b.HasIndex("ReservationId");

                    b.HasIndex("SessionId");

                    b.ToTable("Seats");
                });

            modelBuilder.Entity("Theater.Models.Session", b =>
                {
                    b.Property<int>("SessionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SessionId"), 1L, 1);

                    b.Property<DateTime>("DateSession")
                        .HasColumnType("datetime2");

                    b.Property<int>("QuantitySeats")
                        .HasColumnType("int");

                    b.Property<int>("ShowId")
                        .HasColumnType("int");

                    b.HasKey("SessionId");

                    b.HasIndex("ShowId");

                    b.ToTable("Sessions");
                });

            modelBuilder.Entity("Theater.Models.Show", b =>
                {
                    b.Property<int>("ShowId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ShowId"), 1L, 1);

                    b.Property<int>("Age")
                        .HasColumnType("int");

                    b.Property<string>("Author")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Banner")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Director")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Genre")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Overview")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Poster")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Scene")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ShowId");

                    b.ToTable("Shows");

                    b.HasData(
                        new
                        {
                            ShowId = 1,
                            Age = 18,
                            Author = "Gaston Leroux",
                            Banner = "https://drive.google.com/file/d/1NGhwQlqgvWOIn57JcsqllUP66iM49Ia2/view?usp=drive_link",
                            Director = "Sara García",
                            Genre = "Musical",
                            Overview = "En la majestuosa Ópera Garnier de París, 'El Fantasma de la Ópera' despliega una intrigante trama donde la talentosa soprano Christine Daaé se encuentra en medio de un apasionante triángulo amoroso. Entre el enigmático Fantasma, un genio musical desfigurado que la guía desde las sombras, y el apasionado vizconde Raoul de Chagny, la historia explora los límites entre la belleza y la fealdad, la obsesión y la devoción, creando una atmósfera fascinante en el esplendor de la ópera parisina. La narrativa se teje con emociones intensas, llevando al espectador a las profundidades de la pasión humana, la tragedia y el misterio en un escenario donde la música y el amor convergen de manera inolvidable.",
                            Poster = "https://drive.google.com/file/d/1y0n2XHUkZDIWD05QYoWkaT_9gCPMkNfc/view?usp=drive_link",
                            Scene = "https://drive.google.com/file/d/1jqkJDVs061aXzFe-FXZpCcoqiy8dE2z4/view?usp=drive_link",
                            Title = "El Fantasma de la Ópera"
                        },
                        new
                        {
                            ShowId = 2,
                            Age = 16,
                            Author = "William Shakespeare",
                            Banner = "https://drive.google.com/file/d/1ZOZLpbUGwXjRRvaYWVTz7h_ucWewv38_/view?usp=drive_link",
                            Director = "Carlos Montoya",
                            Genre = "Tragedia",
                            Overview = "En los páramos de Escocia, 'Macbeth' despliega una trama de ambición y traición. La obra sigue al valiente guerrero Macbeth, quien, tras un encuentro con tres brujas proféticas, es tentado por el deseo de poder. Instigado por su esposa, Lady Macbeth, Macbeth asesina al rey Duncan y se sumerge en un oscuro camino de conspiración y asesinato para asegurar su reinado. La historia se sumerge en la psique de Macbeth, donde la ambición y la culpa chocan de manera intensa. Las consecuencias de sus acciones desatan una espiral de violencia y desconfianza, llevándolo a un destino trágico. 'Macbeth' explora las complejidades del poder, la moral y la corrupción en un oscuro escenario donde las decisiones desencadenan consecuencias irreversibles.",
                            Poster = "https://drive.google.com/file/d/1-gJpYA2C-H5xZlvOUZE77oKgPihBjDg4/view?usp=drive_link",
                            Scene = "https://drive.google.com/file/d/1BjnQ80OFheoePkn9i3BpKbM5cUSajQ0K/view?usp=drive_link",
                            Title = "Macbeth"
                        },
                        new
                        {
                            ShowId = 3,
                            Age = 14,
                            Author = "William Shakespeare",
                            Banner = "https://drive.google.com/file/d/17GWvt66xTo_n1viXyKmG0S4zIT1FUpUh/view?usp=drive_link",
                            Director = "Ana Sánchez",
                            Genre = "Musical",
                            Overview = "En el intrigante escenario de la corte danesa, 'Hamlet' despliega una trama de venganza y dilemas morales. El príncipe Hamlet, sumido en la pena por la muerte de su padre, el rey, descubre un perturbador secreto: su tío Claudio ha usurpado el trono y se ha casado con la madre de Hamlet, la reina Gertrudis. Atormentado por la revelación y la sombra del fantasma de su padre, Hamlet se ve envuelto en una espiral de intriga y desconfianza. La obra explora la compleja psicología de Hamlet mientras navega por las tensiones familiares y la búsqueda de justicia. Las dudas, las reflexiones filosóficas y la tragedia se entrelazan en esta historia llena de engaños y traiciones. 'Hamlet' lleva al espectador a través de un viaje emocional y reflexivo, explorando la naturaleza de la venganza y las consecuencias de las decisiones tomadas en un entorno palaciego cargado de intrigas y secretos.",
                            Poster = "https://drive.google.com/file/d/18h893tKSQQShPmN4VYa1KrzvPxq7mb1M/view?usp=drive_link",
                            Scene = "https://drive.google.com/file/d/1oRJz3seD4ZWeHe6wZ7LnVnsYaDg7wY-q/view?usp=drive_link",
                            Title = "Hamlet"
                        },
                        new
                        {
                            ShowId = 4,
                            Age = 16,
                            Author = "Andrew Lloyd Webber",
                            Banner = "https://drive.google.com/file/d/1QSDgZE7HwZHFwo4iIKHYRm5KkmJBbPSB/view?usp=drive_link",
                            Director = "Daniela Méndez",
                            Genre = "Ballet",
                            Overview = "En un encantador escenario invernal, 'El Cascanueces' sumerge al público en un mundo de fantasía y magia. La historia comienza durante una celebración navideña en la casa de los Stahlbaum, donde la joven Clara recibe un regalo especial, un cascanueces de madera. En medio de la noche, el Cascanueces cobra vida, y Clara se embarca en una extraordinaria aventura a través de reinos mágicos. La trama se desarrolla en el Reino de los Dulces, gobernado por la Hada de Azúcar, y enfrenta a Clara y al Cascanueces contra el malvado Rey Ratón. A medida que la historia se desenvuelve, se despliega un deslumbrante despliegue de danzas y personajes, desde los exquisitos Copos de Nieve hasta los encantadores Azúcares y Flores. 'El Cascanueces' captura la imaginación con su encanto, transportando al público a un mundo de sueños donde la magia y la danza se entrelazan en una celebración inolvidable de la fantasía navideña.",
                            Poster = "https://drive.google.com/file/d/16_V6zHu2gpVnwF3rTJezT_Ktk6B-EzHw/view?usp=drive_link",
                            Scene = "https://drive.google.com/file/d/1Brx4QJn7s_-TXOF7Iwd1woTW-SUYN7r6/view?usp=drive_link",
                            Title = "El Cascanueces"
                        },
                        new
                        {
                            ShowId = 5,
                            Age = 18,
                            Author = "Dante Alighieri",
                            Banner = "https://drive.google.com/file/d/19Dj84rZ4DO6Dj7iwpaYFccgfLY_2lCJJ/view?usp=drive_link",
                            Director = "Luis Rosa",
                            Genre = "Drama",
                            Overview = "En los oscuros confines del Infierno hasta las alturas celestiales del Paraíso, 'La Divina Comedia' de Dante Alighieri es un viaje épico a través de los reinos de ultratumba. La trama sigue al poeta Dante, quien se encuentra perdido en un bosque oscuro y es guiado por el espíritu de Virgilio a través de los nueve círculos del Infierno. En este viaje, Dante encuentra a figuras históricas y mitológicas, cada una castigada por sus pecados de acuerdo con la justicia divina. A medida que Dante asciende desde el Infierno, atraviesa el monte del Purgatorio, donde las almas buscan la redención. Finalmente, alcanza el Paraíso, donde su amada Beatriz lo conduce a través de los cielos, revelando los misterios divinos. 'La Divina Comedia' explora la teología, la moral y la redención, ofreciendo una visión poética y filosófica de la vida humana y la relación con lo divino en un viaje que trasciende los límites terrenales hacia las profundidades del alma y la eternidad.",
                            Poster = "https://drive.google.com/file/d/1LGR7FzcanTBBW01w_XtmsqEKj7JFVY8K/view?usp=drive_link",
                            Scene = "https://drive.google.com/file/d/1UdOt-xBNm5L58GhnSeJ_Fwlgf31ZbIJb/view?usp=drive_link",
                            Title = "Divina Comedia"
                        },
                        new
                        {
                            ShowId = 6,
                            Age = 16,
                            Author = "Sófocles",
                            Banner = "https://drive.google.com/file/d/1qbLKuUyzSOYnuyBaOk1PSSbY4UU73vvi/view?usp=drive_link",
                            Director = "Rafael López",
                            Genre = "Tragedia",
                            Overview = "En la ciudad de Tebas, 'Edipo Rey' de Sófocles narra una tragedia impactante que sigue la vida del rey Edipo. La historia comienza con la ciudad asolada por la peste, y Edipo, decidido a encontrar la causa de esta calamidad, inicia una investigación que revela oscuros secretos. Edipo descubre que es el culpable involuntario del incesto y el parricidio, eventos predichos por el oráculo mucho tiempo atrás. El protagonista, ignorante de su linaje, se enfrenta a la dolorosa verdad de su destino trágico. La obra explora temas como el libre albedrío, el destino y la ceguera frente a la verdad, llevando a la audiencia a través de una emocionante travesía psicológica mientras Edipo lucha contra las inevitables consecuencias de su propio desconocimiento y las decisiones de aquellos que lo precedieron.",
                            Poster = "https://drive.google.com/file/d/1CTLJ4JGviv9uhGZI6QwEva8DbUJ5wv2R/view?usp=drive_link",
                            Scene = "n",
                            Title = "Edipo Rey"
                        },
                        new
                        {
                            ShowId = 7,
                            Age = 16,
                            Author = "William Shakespeare",
                            Banner = "https://drive.google.com/file/d/1jKvBobDQ_pn7kzt3QZi02pJVIFcaSzUW/view?usp=drive_link",
                            Director = "Marta Váldez",
                            Genre = "Tragedia",
                            Overview = "En la vibrante ciudad de Verona, 'Romeo y Julieta' de William Shakespeare relata un apasionado y trágico romance entre dos jóvenes de familias enemistadas, los Montesco y los Capuleto. La historia se inicia con un encuentro fortuito en una fiesta, donde los jóvenes enamorados, Romeo y Julieta, se ven irresistiblemente atraídos el uno al otro. A pesar de las tensiones familiares, deciden casarse en secreto, desencadenando una serie de eventos fatídicos. Los desafíos que enfrentan por el odio ancestral entre sus casas culminan en un desenlace desgarrador. 'Romeo y Julieta' explora la intensidad del amor juvenil, la imprudencia de la pasión y las consecuencias trágicas que pueden surgir cuando el destino se interpone en el camino del amor verdadero. La obra de Shakespeare sigue siendo un testamento atemporal del poder del amor y las trágicas consecuencias de la enemistad desmedida.",
                            Poster = "https://drive.google.com/file/d/1PZ9cy2LlNhn_r2JM8z0UFQQK8-3Kka3s/view?usp=drive_link",
                            Scene = "https://drive.google.com/file/d/1mbTMT9cVxGG6M8I6Y3vC9F2SHxxRwHFe/view?usp=drive_link",
                            Title = "Romeo y Julieta"
                        },
                        new
                        {
                            ShowId = 8,
                            Age = 14,
                            Author = "Alan Jay Lerner",
                            Banner = "https://drive.google.com/file/d/1I9oB3EYMm_jVQhqoHHYxhLMXChta3uwS/view?usp=drive_link",
                            Director = "Domingo Gómez",
                            Genre = "Musical",
                            Overview = "En el mágico reino de Camelot, la obra 'Camelot' de Alan Jay Lerner transporta a los espectadores a un mundo de mitos y nobleza. La trama sigue al legendario Rey Arturo, la reina Ginebra y el apasionado caballero Lanzarote, explorando la fundación utópica de Camelot y los desafíos que surgen cuando un triángulo amoroso amenaza con socavar los nobles ideales del reino. Con una emotiva banda sonora que resalta los momentos de amor y traición, 'Camelot' se erige como un clásico teatral que captura la eterna lucha entre el deber y el deseo, ofreciendo una mirada atemporal a la fragilidad de los ideales frente a las complejidades del amor y la moral.",
                            Poster = "https://drive.google.com/file/d/1wNM6XE-jDR-h7Nhpc_WIHEnzi212rE87/view?usp=drive_link",
                            Scene = "https://drive.google.com/file/d/1ZvyjfiCNJF1jAbP79G7YAFwWfTGNE3ho/view?usp=drive_link",
                            Title = "Camelot"
                        },
                        new
                        {
                            ShowId = 9,
                            Age = 16,
                            Author = "Molière",
                            Banner = "https://drive.google.com/file/d/1ox73tXCUUo6shuuHzBUEuanichBNDhQw/view?usp=drive_link",
                            Director = "José Luis Alonso",
                            Genre = "Comedia",
                            Overview = "En el animado escenario de la comedia clásica 'Las Preciosas Ridículas' de Molière, la trama se desenvuelve en la París del siglo XVII, ofreciendo una sátira ingeniosa sobre la afectación y la superficialidad de la sociedad de la época. La obra sigue a las encantadoras pero vanidosas señoritas Magdelón y Cathos, quienes, en su afán por ascender socialmente, se ven envueltas en enredos cómicos. La trama se desata cuando las preciosas creen estar cortejando a dos hombres de alta alcurnia, sin percatarse de la farsa que los caballeros y sus criados han orquestado. Con agudo ingenio y diálogos mordaces, Molière pinta un retrato humorístico de la afectación y la hipocresía social. 'Las Preciosas Ridículas' se destaca por su agudeza satírica, abordando con destreza las contradicciones humanas mientras ofrece una mirada entretenida y atemporal a las idiosincrasias de la sociedad.",
                            Poster = "https://drive.google.com/file/d/1-u8OVywSajG863ZysYGQa3es6FIx4jz_/view?usp=drive_link",
                            Scene = "https://drive.google.com/file/d/13kHTAqTMfP_DYj-GmjZZdmSoznW3R9KQ/view?usp=drive_link",
                            Title = "Las Preciosas Ridículas"
                        },
                        new
                        {
                            ShowId = 10,
                            Age = 12,
                            Author = "Fernando de Rojas",
                            Banner = "https://drive.google.com/file/d/1FP3T9cm6ytOt8IikbdIgnb68KNc1_Rhy/view?usp=drive_link",
                            Director = "Macarena Gil",
                            Genre = "Drama",
                            Overview = "En el oscuro escenario medieval de 'La Celestina', la obra maestra trágica de Fernando de Rojas, se despliega un drama que escudriña las complejidades de la pasión, la codicia y el poder. La trama se centra en la historia de Calisto y Melibea, dos jóvenes amantes cuya relación prohibida desencadena una serie de eventos desgarradores. La figura de la astuta Celestina, una alcahueta manipuladora, emerge como el catalizador de la tragedia al utilizar sus artimañas para propiciar encuentros clandestinos. Rojas examina las oscuras facetas del deseo humano y la vulnerabilidad de la moralidad en una sociedad corrupta. Con diálogos intensos y personajes complejos, 'La Celestina' se erige como una obra inmortal que desentraña las complejidades de la naturaleza humana, destacando la fragilidad de las relaciones y los peligros que surgen cuando la pasión se desborda.",
                            Poster = "https://drive.google.com/file/d/11ZeGz4U1CzFBBjTqm3ItGRZ6xTwdpBpj/view?usp=drive_link",
                            Scene = "https://drive.google.com/file/d/1TtL-dEo7yaXi1k3O3z6XN1vM-XC1UoBl/view?usp=drive_link",
                            Title = "La Celestina"
                        },
                        new
                        {
                            ShowId = 11,
                            Age = 14,
                            Author = "Oscar Wilde",
                            Banner = "https://drive.google.com/file/d/1KheIyggXx2I1SKHfdASHdKs-d7OEqr2G/view?usp=drive_link",
                            Director = "Pedro Jiménez",
                            Genre = "Comedia",
                            Overview = "En el elegante mundo de la alta sociedad victoriana, 'Un Marido Ideal' de Oscar Wilde despliega una comedia satírica que revela las intrigas y secretos ocultos detrás de las fachadas de respetabilidad. La trama sigue al político Sir Robert Chiltern, cuyo prestigio se ve amenazado cuando un oscuro secreto de su pasado es descubierto por la intrigante Mrs. Cheveley. Con su característico ingenio, Wilde teje una trama repleta de diálogos agudos y situaciones cómicas mientras examina la hipocresía y las dobles morales de la sociedad de la época. 'Un Marido Ideal' ofrece una mirada satírica a la moralidad, la corrupción y la fragilidad de las reputaciones en una sociedad obsesionada por las apariencias. Con personajes inolvidables y giros inesperados, la obra sigue siendo una comedia atemporal que invita a la reflexión sobre la naturaleza humana y la moralidad.",
                            Poster = "https://drive.google.com/file/d/1QZHM1CS4svOh46zPjkXIS2FZX8-JTjrp/view?usp=drive_link",
                            Scene = "https://drive.google.com/file/d/1eWRkNSJh6Jcmqy3tLno3R21APGdJLwsv/view?usp=drive_link",
                            Title = "Un Marido Ideal"
                        },
                        new
                        {
                            ShowId = 12,
                            Age = 10,
                            Author = "Agatha Christie",
                            Banner = "https://drive.google.com/file/d/1dcn5n3FuiP78V-lU6-xWx5dncN1dL9It/view?usp=drive_link",
                            Director = "María García",
                            Genre = "Misterio",
                            Overview = "En el intrigante escenario de 'La Ratonera' de Agatha Christie, los espectadores se sumergen en un misterio envolvente que se desarrolla en el pintoresco Molino Monkswell. La historia comienza cuando un grupo ecléctico de personajes se ve atrapado en una posada durante una tormenta de nieve, desencadenando una serie de eventos que revelan oscuros secretos y conexiones sorprendentes. La trama se teje con maestría, dejando que la sospecha recaiga sobre cada personaje mientras el misterio se desenvuelve. Con giros inesperados y un ingenioso desenlace, Agatha Christie cautiva a la audiencia con su habilidad para mantener en vilo hasta el último momento. 'La Ratonera' se erige como un clásico del suspense, explorando la complejidad de la naturaleza humana y la imprevisibilidad de los secretos bien guardados, dejando a los espectadores absortos en la intriga y el suspenso hasta la última revelación.",
                            Poster = "https://drive.google.com/file/d/11lKDLzypERZiOHl0MGALoB6dBVNs3OfP/view?usp=drive_link",
                            Scene = "https://drive.google.com/file/d/15FbPzaiMrUuv3NHk8PZvTbErAEWxxPjb/view?usp=drive_link",
                            Title = "La Ratonera"
                        });
                });

            modelBuilder.Entity("Theater.Models.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UserId"), 1L, 1);

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsAdmin")
                        .HasColumnType("bit");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserLastname")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            UserId = 1,
                            Email = "a26619@svalero.com",
                            IsAdmin = true,
                            Password = "1234",
                            PhoneNumber = "123456789",
                            UserLastname = "Mateo",
                            UserName = "Paula"
                        });
                });

            modelBuilder.Entity("Theater.Models.Reservation", b =>
                {
                    b.HasOne("Theater.Models.Session", "Session")
                        .WithMany("Reservations")
                        .HasForeignKey("SessionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Theater.Models.User", "User")
                        .WithMany("Reservations")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Session");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Theater.Models.Seat", b =>
                {
                    b.HasOne("Theater.Models.Reservation", null)
                        .WithMany("SeatsReserved")
                        .HasForeignKey("ReservationId");

                    b.HasOne("Theater.Models.Session", null)
                        .WithMany("Seats")
                        .HasForeignKey("SessionId");
                });

            modelBuilder.Entity("Theater.Models.Session", b =>
                {
                    b.HasOne("Theater.Models.Show", "Show")
                        .WithMany("Sessions")
                        .HasForeignKey("ShowId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Show");
                });

            modelBuilder.Entity("Theater.Models.Reservation", b =>
                {
                    b.Navigation("SeatsReserved");
                });

            modelBuilder.Entity("Theater.Models.Session", b =>
                {
                    b.Navigation("Reservations");

                    b.Navigation("Seats");
                });

            modelBuilder.Entity("Theater.Models.Show", b =>
                {
                    b.Navigation("Sessions");
                });

            modelBuilder.Entity("Theater.Models.User", b =>
                {
                    b.Navigation("Reservations");
                });
#pragma warning restore 612, 618
        }
    }
}