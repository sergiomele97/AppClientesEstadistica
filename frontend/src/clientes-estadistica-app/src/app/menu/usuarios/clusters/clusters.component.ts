import { Component, OnInit } from '@angular/core';
import { ClustersDataService } from 'src/app/servicios/clusters-data.service';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-clusters',
  templateUrl: './clusters.component.html',
  styleUrls: ['./clusters.component.css'],
})

///////////////////////////////////////
export class ClustersComponent implements OnInit {

constructor(private dataService: ClustersDataService,private http: HttpClient) {}
private apiUrl = 'http://127.0.0.1:5000/cluster';


  ngOnInit() {
  }
//////////////////////////////
async onSelectionCluster(event: Event) {
    const selectElement = event.target as HTMLSelectElement;
    const numerosSelect = selectElement.value;
    console.log('El cluster es ', numerosSelect);
    const n_cluster = parseInt(numerosSelect, 10);
    this.dataService.setSelectednCluster(n_cluster);
    
      // Call sendDataToBackend and handle the response
      try {
        // Convert Observables to Promises
        const data = this.dataService.selectedData$;
        // Send data to backend
        const response = await this.http.post<any>(this.apiUrl, { data, n_cluster }).toPromise();
    
        // Handle response
        console.log('Received data:', response);
        const etiqueta = response.etiqueta || [];
        console.log('etiqueta:', etiqueta);
        // Set label in the service
        
  
      } catch (error) {
        // Handle errors
        console.error('Error al enviar datos al backend:', error);
        throw new Error('Error al enviar datos al backend');
      }
 
  }
  ////////////////////////////
   onSelectionChange(event: Event) {
    const selectElement = event.target as HTMLSelectElement;
    const selectedSample = selectElement.value;
    const sampleData = this.getSampleData(selectedSample);
  
    // Set the selected data
    this.dataService.setSelectedData(sampleData);
  
  }
  
//////////////////////////////
    private getSampleData(selectedSample: string): any[] {
      switch (selectedSample) {
        case 'sample a':
          return  [
            [16.4, 5.4], [21.7, 2], [25.4, 3], [19, 2], [10.9, 1],
            [13.6, 3.2], [10.9, 7.4], [10.9, 0], [10.9, 8.2], [16.4, 0],
            [16.4, 1.8], [13.6, 0.3], [13.6, 0], [29.9, 0], [27.1, 2.3],
            [16.4, 0], [13.6, 3.7], [10.9, 5.2], [16.4, 6.5], [10.9, 0],
            [24.5, 7.1], [10.9, 0], [8.1, 4.7], [19, 0], [21.7, 1.8],
            [27.1, 0], [24.5, 0], [27.1, 0], [29.9, 1.5], [27.1, 0.8],
            [22.1, 2],
          ];
        case 'sample b':
          return[
            [36.4, 13.4], [1.7, 11], [5.4, 8], [9, 17], [1.9, 4],
            [3.6, 12.2], [1.9, 14.4], [1.9, 9], [1.9, 13.2], [1.4, 7],
            [6.4, 8.8], [3.6, 4.3], [1.6, 10], [9.9, 2], [7.1, 15],
            [1.4, 0], [3.6, 13.7], [1.9, 15.2], [6.4, 16.5], [0.9, 10],
            [4.5, 17.1], [10.9, 10], [0.1, 14.7], [9, 10], [12.7, 11.8],
            [2.1, 10], [2.5, 10], [27.1, 10], [2.9, 11.5], [7.1, 10.8],
            [2.1, 12]
          ];
        case 'sample c':
          return [
            [21.7, 3], [23.6, 3.5], [24.6, 3], [29.9, 3], [21.7, 20],
            [23, 2], [10.9, 3], [28, 4], [27.1, 0.3], [16.4, 4],
            [13.6, 0], [19, 5], [22.4, 3], [24.5, 3], [32.6, 3],
            [27.1, 4], [29.6, 6], [31.6, 8], [21.6, 5], [20.9, 4],
            [22.4, 0], [32.6, 10.3], [29.7, 20.8], [24.5, 0.8],
            [21.4, 0], [21.7, 6.9], [28.6, 7.7], [15.4, 0], [18.1, 0],
            [33.4, 0], [16.4, 0],
          ];
        default:
          return [];  // Retorna un array vacío si no se encuentra el sample
      }
    }

  
          
      
  }    