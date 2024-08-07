import { Component, ViewChild } from '@angular/core';
import { ClustersDataService } from 'src/app/servicios/clusters-data.service';

import {
  ChartComponent,
  ApexAxisChartSeries,
  ApexChart,
  ApexYAxis,
  ApexXAxis,
} from 'ng-apexcharts';

export type ChartOptions = {
  series: ApexAxisChartSeries;
  chart: ApexChart;
  xaxis: ApexXAxis;
  yaxis: ApexYAxis;
};

@Component({
  selector: 'app-clusters-graph',
  templateUrl: './clusters-graph.component.html',
  styleUrls: ['./clusters-graph.component.css'],
})
export class ClustersGraphComponent {
  @ViewChild('chart') chart: ChartComponent;
  public chartOptions: Partial<ChartOptions>;

  constructor(private dataService: ClustersDataService) {
    this.chartOptions = {
      series: [],
      chart: {
        height: 350,
        type: 'scatter',
        zoom: {
          enabled: true,
          type: 'xy',
        },
      },
      xaxis: {
        tickAmount: 10,
        labels: {
          formatter: function (val) {
            return parseFloat(val).toFixed(1);
          },
        },
      },
      yaxis: {
        tickAmount: 7,
      },
    };
  }

  ngOnInit() {
    this.dataService.selectedData$.subscribe(data => {
      this.updateChartData(data);
    });
    this.dataService.selectedCluster$.subscribe(nCluster => {
      this.updateChartData(nCluster);
    });
  }

  updateChartData(data: any[]) {
    this.chartOptions.series = [{
      name: 'Selected Sample',
      data: data
    }];
  }
  updateChartCluster(nCluster: any) {
      this.chartOptions.series = [{
        name: 'Selected cluster number',
        data: nCluster
      }];
  }
}
