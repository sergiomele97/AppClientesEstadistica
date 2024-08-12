import { Component, OnInit } from '@angular/core';
import { ClustersDataService } from 'src/app/servicios/clusters-data.service';

@Component({
  selector: 'app-clusters-table',
  templateUrl: './clusters-table.component.html',
  styleUrls: ['./clusters-table.component.css']
})

export class ClustersTableComponent implements OnInit {
  public tableData: any[] = [];

  constructor(private dataService: ClustersDataService) { }

  ngOnInit() {
    this.dataService.selectedData$.subscribe(data => {
      this.tableData = data;
    });
  }
}