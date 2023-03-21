﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ApiUsageChallenge
{
    
   
    public class Person
    {
        [JsonConstructor]
        public Person(string? name, string? height, string? mass, string? hairColor, string? skinColor, string? eyeColor, string? birthYear, string? gender, string? homeworld, List<string>? films, List<object>? species, List<string>? vehicles, List<string>? starships, DateTime created, DateTime edited, string? url)
        {
            Name = name;
            Height = height;
            Mass = mass;
            HairColor = hairColor;
            SkinColor = skinColor;
            EyeColor = eyeColor;
            BirthYear = birthYear;
            Gender = gender;
            Homeworld = homeworld;
            Films = films;
            Species = species;
            Vehicles = vehicles;
            Starships = starships;
            Created = created;
            Edited = edited;
            Url = url;
        }

        [JsonProperty("name")]
        public string? Name { get; set; }

        [JsonProperty("height")]
        public string? Height { get; set; }

        [JsonProperty("mass")]
        public string? Mass { get; set; }

        [JsonProperty("hair_color")]
        public string? HairColor { get; set; }

        [JsonProperty("skin_color")]
        public string? SkinColor { get; set; }

        [JsonProperty("eye_color")]
        public string? EyeColor { get; set; }

        [JsonProperty("birth_year")]
        public string? BirthYear { get; set; }

        [JsonProperty("gender")]
        public string? Gender { get; set; }

        [JsonProperty("homeworld")]
        public string? Homeworld { get; set; }

        [JsonProperty("films")]
        public List<string>? Films { get; set; }

        [JsonProperty("species")]
        public List<object>? Species { get; set; }

        [JsonProperty("vehicles")]
        public List<string>? Vehicles { get; set; }

        [JsonProperty("starships")]
        public List<string>? Starships { get; set; }

        [JsonProperty("created")]
        public DateTime Created { get; set; }

        [JsonProperty("edited")]
        public DateTime Edited { get; set; }

        [JsonProperty("url")]
        public string? Url { get; set; }
       
    }


}
