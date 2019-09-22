using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnTheFly.Core.Api
{
    public class PlacesResponse
    {
        [JsonProperty(PropertyName = "name")]
        public string Name;
        [JsonProperty(PropertyName = "code")]
        public string Code;
        [JsonProperty(PropertyName = "country_name")]
        public string CountryName;
        /*
         {
  "code": MOW,
  "main_airport_name": null,
  "country_cases": null,
  "index_strings":[
    maskava,
    moscow
  ],
  "weight": 1006321,
  "cases": {
    "da": "Москве",
    "tv": "Москвой",
    "vi": "в Москву",
    "pr": "Москве",
    "ro": "Москвы"
  },
  "country_name": "Россия",
  "type": city,
  "country_code": RU,
  "coordinates": {
    "lon": 37.617633,
    "lat": 55.755786
  },
  "name": "Москва",
  "state_code": null
  */
    }
}
