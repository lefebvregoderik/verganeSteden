using Xunit;
using FakeItEasy;
using VerganeSteden.GameObjects;
using FluentAssertions;
using VerganeSteden.Enum;
using System;
using VerganeSteden.Exceptions;
using System.Linq;

namespace VerganeStedenTests
{
    public class OntdekkingsStapelTests
    {
        [Fact]
        public void Waarde_MetLegeStapel_IsMin20()
        {
            // Arrange
            OntdekkingsStapel ontdekkingsStapel = new OntdekkingsStapel();

            // Act & Assert
            ontdekkingsStapel.Waarde.Should().Be(0);
        }

        [Fact]
        public void Waarde_GestarteOntdekking_StartBijMinStartwaarde()
        {
            // Arrange
            int waarde = 7;
            Kaart kaart = new Kaart { Waarde = waarde };
            OntdekkingsStapel ontdekkingsStapel = new OntdekkingsStapel();
            ontdekkingsStapel.Stapel.Add(kaart);

            // Act & Assert
            ontdekkingsStapel.Waarde.Should().Be(waarde + OntdekkingsStapel.startwaarde);
        }

        [Fact]
        public void Waarde_StapelMetMinderDan8Kaarten_WordtNietVerhoogdMetBonus()
        {
            // Arrange
            Kaart kaart1 = new Kaart { Waarde = 1 };
            Kaart kaart2 = new Kaart { Waarde = 2 };
            Kaart kaart3 = new Kaart { Waarde = 3 };
            Kaart kaart4 = new Kaart { Waarde = 4 };
            Kaart kaart5 = new Kaart { Waarde = 5 };
            Kaart kaart6 = new Kaart { Waarde = 6 };
            OntdekkingsStapel ontdekkingsStapel = new OntdekkingsStapel();
            ontdekkingsStapel.Stapel.Add(kaart1);
            ontdekkingsStapel.Stapel.Add(kaart2);
            ontdekkingsStapel.Stapel.Add(kaart3);
            ontdekkingsStapel.Stapel.Add(kaart4);
            ontdekkingsStapel.Stapel.Add(kaart5);
            ontdekkingsStapel.Stapel.Add(kaart6);
            int som = 1 + 2 + 3 + 4 + 5 + 6;

            // Act & Assert           
            ontdekkingsStapel.Waarde.Should().Be(som + OntdekkingsStapel.startwaarde);
        }

        [Fact]
        public void Waarde_StapelVanaf8Kaarten_WordtVerhoogdMetBonus()
        {
            // Arrange
            Kaart kaart1 = new Kaart { Waarde = 1 };
            Kaart kaart2 = new Kaart { Waarde = 2 };
            Kaart kaart3 = new Kaart { Waarde = 3 };
            Kaart kaart4 = new Kaart { Waarde = 4 };
            Kaart kaart5 = new Kaart { Waarde = 5 };
            Kaart kaart6 = new Kaart { Waarde = 6 };
            Kaart kaart7 = new Kaart { Waarde = 7 };
            Kaart kaart8 = new Kaart { Waarde = 8 };
            OntdekkingsStapel ontdekkingsStapel = new OntdekkingsStapel();
            ontdekkingsStapel.Stapel.Add(kaart1);
            ontdekkingsStapel.Stapel.Add(kaart2);
            ontdekkingsStapel.Stapel.Add(kaart3);
            ontdekkingsStapel.Stapel.Add(kaart4);
            ontdekkingsStapel.Stapel.Add(kaart5);
            ontdekkingsStapel.Stapel.Add(kaart6);
            ontdekkingsStapel.Stapel.Add(kaart7);
            ontdekkingsStapel.Stapel.Add(kaart8);
            int som = 1 + 2 + 3 + 4 + 5 + 6 + 7 + 8;

            // Act & Assert
            ontdekkingsStapel.Waarde.Should().Be(som + OntdekkingsStapel.startwaarde + OntdekkingsStapel.bonus);
        }

        [Fact]
        public void Waarde_MetEenVermenigvuldiger_VerdubbeldWaarde() {
            // Arrange
            Kaart vermenigvuldiger = new Kaart { IsVermenigvuldiger = true };
            int waarde = 7;
            Kaart kaart7 = new Kaart { Waarde = waarde };
            OntdekkingsStapel ontdekkingsStapel = new OntdekkingsStapel();
            ontdekkingsStapel.Stapel.Add(vermenigvuldiger);
            ontdekkingsStapel.Stapel.Add(kaart7);

            // Act & Assert
            ontdekkingsStapel.Waarde.Should().Be(2 * (waarde + OntdekkingsStapel.startwaarde));
        }

        [Fact]
        public void Waarde_MetTweeVermenigvuldigers_vermenigvuldigdWaardeMetDrie()
        {
            // Arrange
            Kaart vermenigvuldiger = new Kaart { IsVermenigvuldiger = true };
            int waarde = 7;
            Kaart kaart7 = new Kaart { Waarde = waarde };
            OntdekkingsStapel ontdekkingsStapel = new OntdekkingsStapel();
            ontdekkingsStapel.Stapel.Add(vermenigvuldiger);
            ontdekkingsStapel.Stapel.Add(vermenigvuldiger);
            ontdekkingsStapel.Stapel.Add(kaart7);

            // Act & Assert
            ontdekkingsStapel.Waarde.Should().Be(3 * (waarde + OntdekkingsStapel.startwaarde));
        }

        [Fact]
        public void Waarde_MetDrieVermenigvuldigers_vermenigvuldigdWaardeMetVier()
        {
            // Arrange
            Kaart vermenigvuldiger = new Kaart { IsVermenigvuldiger = true };
            int waarde = 7;
            Kaart kaart7 = new Kaart { Waarde = waarde };
            OntdekkingsStapel ontdekkingsStapel = new OntdekkingsStapel();
            ontdekkingsStapel.Stapel.Add(vermenigvuldiger);
            ontdekkingsStapel.Stapel.Add(vermenigvuldiger);
            ontdekkingsStapel.Stapel.Add(vermenigvuldiger);
            ontdekkingsStapel.Stapel.Add(kaart7);

            // Act & Assert
            ontdekkingsStapel.Waarde.Should().Be(4 * (waarde + OntdekkingsStapel.startwaarde));
        }

        [Fact]
        public void Waarde_StapelVanaf8KaartenMetVermenigvuldiger_WordtBonusNietVermenigvuldigd()
        {
            // Arrange
            Kaart kaartV = new Kaart { Waarde = 0, IsVermenigvuldiger = true };
            Kaart kaart1 = new Kaart { Waarde = 1 };
            Kaart kaart2 = new Kaart { Waarde = 2 };
            Kaart kaart3 = new Kaart { Waarde = 3 };
            Kaart kaart4 = new Kaart { Waarde = 4 };
            Kaart kaart5 = new Kaart { Waarde = 5 };
            Kaart kaart6 = new Kaart { Waarde = 6 };
            Kaart kaart7 = new Kaart { Waarde = 7 };
            Kaart kaart8 = new Kaart { Waarde = 8 };
            OntdekkingsStapel ontdekkingsStapel = new OntdekkingsStapel();
            ontdekkingsStapel.Stapel.Add(kaartV);
            ontdekkingsStapel.Stapel.Add(kaart1);
            ontdekkingsStapel.Stapel.Add(kaart2);
            ontdekkingsStapel.Stapel.Add(kaart3);
            ontdekkingsStapel.Stapel.Add(kaart4);
            ontdekkingsStapel.Stapel.Add(kaart5);
            ontdekkingsStapel.Stapel.Add(kaart6);
            ontdekkingsStapel.Stapel.Add(kaart7);
            ontdekkingsStapel.Stapel.Add(kaart8);
            int som = 1 + 2 + 3 + 4 + 5 + 6 + 7 + 8;

            // Act & Assert
            ontdekkingsStapel.Waarde.Should().
                Be((2 * (som + OntdekkingsStapel.startwaarde)) + OntdekkingsStapel.bonus);
        }

        [Fact]
        public void KaartSpelen_MetOngeldigeKaart_Smijt_OngeldigeZetException()
        {
            // Arrange
            Kaart kaart2 = new Kaart { Waarde = 2 };
            OntdekkingsStapel ontdekkingsStapel = new OntdekkingsStapel();
            ontdekkingsStapel.Stapel.Add(kaart2);
            Kaart kaart1 = new Kaart { Waarde = 1 };

            // Act & Assert
            Action act = () => ontdekkingsStapel.SpeelKaart(kaart1);
            act.Should().Throw<OngeldigeZetException>();
        }

        [Fact]
        public void KaartSpelen_MetgeldigeKaart_SmijtGeen_OngeldigeZetException()
        {
            // Arrange
            Kaart kaart1 = new Kaart { Waarde = 1 };
            OntdekkingsStapel ontdekkingsStapel = new OntdekkingsStapel();
            ontdekkingsStapel.Stapel.Add(kaart1);
            Kaart kaart2 = new Kaart { Waarde = 2 };

            // Act & Assert
            Action act = () => ontdekkingsStapel.SpeelKaart(kaart2);
            act.Should().NotThrow<OngeldigeZetException>();
        }

        [Fact]
        public void KaartSpelen_MetgeldigeKaart_VoegtKaartToeAanStapel()
        {
            // Arrange
            Kaart kaart1 = new Kaart { Waarde = 1 };
            OntdekkingsStapel ontdekkingsStapel = new OntdekkingsStapel();
            ontdekkingsStapel.Stapel.Add(kaart1);
            Kaart kaart2 = new Kaart { Waarde = 2 };

            // Act 
            ontdekkingsStapel.SpeelKaart(kaart2);

            // Assert
            ontdekkingsStapel.Stapel.Count.Should().Be(2);
            ontdekkingsStapel.Stapel.Last().Should().Be(kaart2);
        }

        [Fact]
        public void MagKaartSpelen_MetAnderKleurDanStapel_RetourneertFalse()
        {
            // Arrange
            Kaart groeneKaart = new Kaart { Kleur = Kleur.groen, Waarde = 2 };
            OntdekkingsStapel rodeStapel = new OntdekkingsStapel { Kleur = Kleur.rood };

            // Act & Assert
            rodeStapel.MagKaartSpelen(groeneKaart).Should().BeFalse();
        }

        [Fact]
        public void MagKaartSpelen_MetLagereWaardeDanKaartBovenaanStapel_RetourneertFalse()
        {
            // Arrange
            Kaart groene2Kaart = new Kaart { Kleur = Kleur.groen, Waarde = 2 };
            Kaart groene7Kaart = new Kaart { Kleur = Kleur.groen, Waarde = 7 };
            OntdekkingsStapel groeneStapel = new OntdekkingsStapel { Kleur = Kleur.groen };
            groeneStapel.Stapel.Add(groene7Kaart);

            // Act && Assert
            groeneStapel.MagKaartSpelen(groene2Kaart).Should().BeFalse();
        }

        [Fact]
        public void MagKaartSpelen_MetZelfdeKleurOpLegeStapel_RetourneertTrue()
        {
            // Arrange
            Kaart groene2Kaart = new Kaart { Kleur = Kleur.groen, Waarde = 2 };
            OntdekkingsStapel groeneStapel = new OntdekkingsStapel { Kleur = Kleur.groen };

            // Act && Assert
            groeneStapel.MagKaartSpelen(groene2Kaart).Should().BeTrue();
        }
    }
}
