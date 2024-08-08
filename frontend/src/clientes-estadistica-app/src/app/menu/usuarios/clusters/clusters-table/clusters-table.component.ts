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

  constructor(private dataService: ClustersDataService) { }

  ngOnInit() {
     // Combina los observables de data y label
     combineLatest([this.dataService.selectedData$, this.dataService.selectedLabel$])
     .subscribe(([data, label]) => {
       // Combina data y label en una estructura adecuada
       this.tableData = data.map((row: any, index: number) => {
         return {
           ...row,
           label: label[index] || 'N/A'  // Asegúrate de que label tenga un valor para cada fila
         };
       });
     });
 }
}