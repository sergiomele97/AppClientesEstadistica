import { Component, OnInit } from '@angular/core';
import { ClustersDataService } from 'src/app/servicios/clusters-data.service';
import { combineLatest } from 'rxjs';

@Component({
  selector: 'app-clusters-table',
  templateUrl: './clusters-table.component.html',
  styleUrls: ['./clusters-table.component.css']
})
export class ClustersTableComponent implements OnInit {
  public tableData: any[] = [];
  public columnHeaders: string[] = [];

  constructor(private dataService: ClustersDataService) { }

  ngOnInit() {
    combineLatest([this.dataService.selectedData$, this.dataService.selectedLabel$])
      .subscribe(([data, label]) => {
        console.log('Data:', data);
        console.log('Label:', label);

        // Verificar si 'data' y 'label' son arrays
        if (!Array.isArray(data) || !Array.isArray(label)) {
          console.error('Data or label is not an array');
          return;
        }

        // Determinar la longitud máxima de los ítems
        const maxItemLength = Math.max(...data.map(item => item.length));
        
        // Generar encabezados dinámicamente
        this.columnHeaders = Array.from({ length: maxItemLength }, (_, i) => `Variable ${i + 1}`);
        this.columnHeaders.push('Etiqueta'); // Añadir encabezado para la etiqueta

        // Mapear 'data' a un formato adecuado
        this.tableData = data.map((item: any[], index: number) => {
          // Asegúrate de que cada ítem tenga longitud máxima con valores vacíos
          const paddedItem = [...item, ...Array(maxItemLength - item.length).fill('')];
          return [...paddedItem, label[index] || 'N/A'];
        });

        console.log('Transformed TableData:', this.tableData);
      });
  }
}
