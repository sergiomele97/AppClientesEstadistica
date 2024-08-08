import { Component, OnInit } from '@angular/core';
import { ClustersDataService } from 'src/app/servicios/clusters-data.service';


@Component({
  selector: 'app-clusters',
  templateUrl: './clusters.component.html',
  styleUrls: ['./clusters.component.css'],
})
export class ClustersComponent implements OnInit {
  private n_cluster: number | null = null;  // Propiedad para almacenar n_cluster

  constructor(private dataService: ClustersDataService) {}



  ngOnInit() {}

  onSelectionCluster(event: Event) {
    const selectElement = event.target as HTMLSelectElement;
    const cluster = selectElement.value;

    this.n_cluster = parseInt(cluster, 10);

    this.dataService.setSelectednCluster(this.n_cluster);
  }

  onSelectionChange(event: Event) {
    const selectElement = event.target as HTMLSelectElement;
    const selectedSample = selectElement.value;

    let sampleData: any[] = [];

    if (selectedSample === 'sample a') {
      sampleData = [
        [16.4, 5.4], [21.7, 2], [25.4, 3], [19, 2], [10.9, 1],
        [13.6, 3.2], [10.9, 7.4], [10.9, 0], [10.9, 8.2], [16.4, 0],
        [16.4, 1.8], [13.6, 0.3], [13.6, 0], [29.9, 0], [27.1, 2.3],
        [16.4, 0], [13.6, 3.7], [10.9, 5.2], [16.4, 6.5], [10.9, 0],
        [24.5, 7.1], [10.9, 0], [8.1, 4.7], [19, 0], [21.7, 1.8],
        [27.1, 0], [24.5, 0], [27.1, 0], [29.9, 1.5], [27.1, 0.8],
        [22.1, 2],
      ];
    } else if (selectedSample === 'sample b') {
      sampleData = [
        [36.4, 13.4], [1.7, 11], [5.4, 8], [9, 17], [1.9, 4],
        [3.6, 12.2], [1.9, 14.4], [1.9, 9], [1.9, 13.2], [1.4, 7],
        [6.4, 8.8], [3.6, 4.3], [1.6, 10], [9.9, 2], [7.1, 15],
        [1.4, 0], [3.6, 13.7], [1.9, 15.2], [6.4, 16.5], [0.9, 10],
        [4.5, 17.1], [10.9, 10], [0.1, 14.7], [9, 10], [12.7, 11.8],
        [2.1, 10], [2.5, 10], [27.1, 10], [2.9, 11.5], [7.1, 10.8],
        [2.1, 12]
      ];
    } else if (selectedSample === 'sample c') {
      sampleData = [
        [21.7, 3], [23.6, 3.5], [24.6, 3], [29.9, 3], [21.7, 20],
        [23, 2], [10.9, 3], [28, 4], [27.1, 0.3], [16.4, 4],
        [13.6, 0], [19, 5], [22.4, 3], [24.5, 3], [32.6, 3],
        [27.1, 4], [29.6, 6], [31.6, 8], [21.6, 5], [20.9, 4],
        [22.4, 0], [32.6, 10.3], [29.7, 20.8], [24.5, 0.8],
        [21.4, 0], [21.7, 6.9], [28.6, 7.7], [15.4, 0], [18.1, 0],
        [33.4, 0], [16.4, 0],
      ];
    }
    

    

    this.dataService.setSelectedData(sampleData);

    if (this.n_cluster !== null && !Number.isNaN(this.n_cluster)) {
      console.log('cluster:', this.n_cluster);
      this.dataService.sendDataToBackend(sampleData, this.n_cluster).subscribe(
        response => {
          console.log('Received data:', response);
          //recogemos los datos del codigo de python
          const etiqueta = response.etiqueta || [];
          const centros = response.centros || [];
          const db_index = response.db_index || [];
          //enviamos el valor de la etiqueta
          this.dataService.setSendLabel(etiqueta);

        },
        error => {
          console.error('Error al enviar datos al backend:', error);
        }
      );
    } else {
      console.error('n_cluster no está definido.');
      this.n_cluster=2;
      this.dataService.sendDataToBackend(sampleData, this.n_cluster).subscribe(
        response => {
          console.log('Received data:', response);
          //recogemos los datos del codigo de python
          const etiqueta = response.etiqueta || [];
          const centros = response.centros || [];
          const db_index = response.db_index || [];
          //enviamos el valor de la etiqueta
          this.dataService.setSendLabel(etiqueta);
          
        },
        error => {
          console.error('Error al enviar datos al backend:', error);
        }
      );
    }
  }
}
