import { Component } from '@angular/core';

import Highcharts from "highcharts/highmaps";
import worldMap from "@highcharts/map-collection/custom/world.geo.json";

@Component({
  selector: 'app-map',
  templateUrl: './map.component.html',
  styleUrls: ['./map.component.css']
})

export class MapComponent {
  
  Highcharts: typeof Highcharts = Highcharts;
  chartConstructor = "mapChart";
  bubbleData = [
    { code3: "ABW", z: 105 },
    { code3: "AFG", z: 35530 },
    { code3: "BRA", z: 27353 },
    { code3: "ESP", z: 74145 },
    { code3: "GBR", z: 46549 },
    { code3: "RUS", z: 14564 },
    { code3: "DEU", z: 54543 },
    { code3: "FRA", z: 24957 },
    { code3: "ITA", z: 74145 },
    { code3: "USA", z: 454834 }
  ];

  chartOptions: Highcharts.Options = {
    chart: {
      borderWidth: 1,
      map: worldMap
    },

    title: {
      text: "World population 2013 by country"
    },

    subtitle: {
      text: "Demo of Highcharts map with bubbles"
    },

    legend: {
      enabled: false
    },

    mapNavigation: {
      enabled: true,
      buttonOptions: {
        verticalAlign: "bottom"
      }
    },

    series: [
      {
        type: "map",
        name: "Countries",
        color: "#E0E0E0",
        enableMouseTracking: false
      },
      {
        type: "mapbubble",
        name: "Population 2016",
        joinBy: ["iso-a3", "code3"],
        data: this.bubbleData,
        minSize: 4,
        maxSize: "12%",
        tooltip: {
          pointFormat: "{point.properties.hc-a2}: {point.z} thousands"
        }
      },
    ]
  };
}
