using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using FakeItEasy;
using VerganeSteden.GameObjects;
using FluentAssertions;
using Business.GameObjects;
using Business.Enum;

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
            Kaart kaart = new Kaart { Waarde = waarde, Kleur = Kleur.groen };
            OntdekkingsStapel ontdekkingsStapel = new OntdekkingsStapel();
            ontdekkingsStapel.Stapel.Add(kaart);

            // Act & Assert
            ontdekkingsStapel.Waarde.Should().Be(waarde + OntdekkingsStapel.startwaarde);
        }

        [Fact]
        public void Waarde_StapelMetMinstens6Kaarten_WordtVerhoogdMet20()
        {
            // Arrange
            Kaart kaart1 = new Kaart { Waarde = 1, Kleur = Kleur.groen };
            Kaart kaart2 = new Kaart { Waarde = 2, Kleur = Kleur.groen };
            Kaart kaart3 = new Kaart { Waarde = 3, Kleur = Kleur.groen };
            Kaart kaart4 = new Kaart { Waarde = 4, Kleur = Kleur.groen };
            Kaart kaart5 = new Kaart { Waarde = 5, Kleur = Kleur.groen };
            Kaart kaart6 = new Kaart { Waarde = 6, Kleur = Kleur.groen };
            OntdekkingsStapel ontdekkingsStapel = new OntdekkingsStapel();
            ontdekkingsStapel.Stapel.Add(kaart1);
            ontdekkingsStapel.Stapel.Add(kaart2);
            ontdekkingsStapel.Stapel.Add(kaart3);
            ontdekkingsStapel.Stapel.Add(kaart4);
            ontdekkingsStapel.Stapel.Add(kaart5);
            ontdekkingsStapel.Stapel.Add(kaart6);

            // Act & Assert
            int som = 1 + 2 + 3 + 4 + 5 + 6;
            ontdekkingsStapel.Waarde.Should().Be(som + OntdekkingsStapel.bonus + OntdekkingsStapel.startwaarde);
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
