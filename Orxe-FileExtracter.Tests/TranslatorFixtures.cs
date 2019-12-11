using System;
using Xunit;
using FluentAssertions;

namespace Orxe_FileExtracter.Tests
{
    public class TranslatorFixtures
    {
        [Fact]
        public void LineString_with_all_fields_must_be_translated_to_place()
        {
            Place expectedPlace = new Place();
            string line = " 704|Barter Island|Barter Island, Alaska, United States of America|70.129562|-143.662949|tree";
            Place actualPlace = FileExtractorTranslator.TranslateToPlace(line);
            expectedPlace.RegionID = "704";
            expectedPlace.RegionName = "Barter Island";
            expectedPlace.RegionNameLong = "Barter Island, Alaska, United States of America";
            expectedPlace.Latitude = "70.129562";
            expectedPlace.Longitude = "-143.662949";
            expectedPlace.SubClassification = "tree";
            actualPlace.Should().BeEquivalentTo(expectedPlace);
        }

        [Fact]
        public void LineString_with_missing_subclassification_must_be_translated_to_place()
        {
            Place expectedPlace = new Place();
            string line = " 704|Barter Island|Barter Island, Alaska, United States of America|70.129562|-143.662949";
            Place actualPlace = FileExtractorTranslator.TranslateToPlace(line);
            expectedPlace.RegionID = "704";
            expectedPlace.RegionName = "Barter Island";
            expectedPlace.RegionNameLong = "Barter Island, Alaska, United States of America";
            expectedPlace.Latitude = "70.129562";
            expectedPlace.Longitude = "-143.662949";
            expectedPlace.SubClassification = "";
            actualPlace.Should().BeEquivalentTo(expectedPlace);
        }

        [Fact]
        public void LineString_with_missing_subclassification_and_Longitude_must_be_translated_to_place()
        {
            Place expectedPlace = new Place();
            string line = " 704|Barter Island|Barter Island, Alaska, United States of America|70.129562";
            Place actualPlace = FileExtractorTranslator.TranslateToPlace(line);
            expectedPlace.RegionID = "704";
            expectedPlace.RegionName = "Barter Island";
            expectedPlace.RegionNameLong = "Barter Island, Alaska, United States of America";
            expectedPlace.Latitude = "70.129562";
            expectedPlace.Longitude = "";
            expectedPlace.SubClassification = "";
            actualPlace.Should().BeEquivalentTo(expectedPlace);
        }

        [Fact]
        public void LineString_with_missing_subclassification_Longitude_and_Latitude_must_be_translated_to_place()
        {
            Place expectedPlace = new Place();
            string line = " 704|Barter Island|Barter Island, Alaska, United States of America";
            Place actualPlace = FileExtractorTranslator.TranslateToPlace(line);
            expectedPlace.RegionID = "704";
            expectedPlace.RegionName = "Barter Island";
            expectedPlace.RegionNameLong = "Barter Island, Alaska, United States of America";
            expectedPlace.Latitude = "";
            expectedPlace.Longitude = "";
            expectedPlace.SubClassification = "";
            actualPlace.Should().BeEquivalentTo(expectedPlace);
        }


        [Fact]
        public void LineString_with_missing_subclassification_Longitude_Latitude_and_RegionNameLong_must_be_translated_to_place()
        {
            Place expectedPlace = new Place();
            string line = " 704|Barter Island";
            Place actualPlace = FileExtractorTranslator.TranslateToPlace(line);
            expectedPlace.RegionID = "704";
            expectedPlace.RegionName = "Barter Island";
            expectedPlace.RegionNameLong = "";
            expectedPlace.Latitude = "";
            expectedPlace.Longitude = "";
            expectedPlace.SubClassification = "";
            actualPlace.Should().BeEquivalentTo(expectedPlace);
        }
    }
}
