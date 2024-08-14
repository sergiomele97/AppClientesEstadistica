import { Component, ComponentRef, ElementRef, OnInit, QueryList, ViewChild, ViewChildren, ViewContainerRef } from '@angular/core';
import { Subscription } from 'rxjs';
import { GraphComponent } from 'src/app/estadisticas/graph/graph.component';
import { MapComponent } from 'src/app/estadisticas/map/map.component';
import { SpaghettiComponent } from 'src/app/estadisticas/spaghetti/spaghetti.component';
import { VolumetryComponent } from 'src/app/estadisticas/volumetry/volumetry.component';
import { GraficasService } from 'src/app/servicios/graficas.service';

@Component({
  selector: 'app-graficas',
  templateUrl: './Graficas.component.html',
  styleUrls: ['./Graficas.component.css']
})
export class GraficasComponent implements OnInit {

  // Esto es para que escuche cuando se cierra una grafica
  private subscription: Subscription;

  
  constructor(private graficasServicio: GraficasService) { }

  ngOnInit() {
    this.subscription = this.graficasServicio.triggerScript$.subscribe(() => {
      this.onGraphClose();
    });
  }


  // Declarar contenedor
  @ViewChild('contenedor1', { read: ViewContainerRef }) container!: ViewContainerRef;

  // Ejecutar cuando se cierra una grafica
  onGraphClose() {
    console.log("Hola")
    
  }

  isComponentVisible(viewRef: any): boolean {
    const element = viewRef.rootNodes[0] as HTMLElement;
    return element && window.getComputedStyle(element).display !== 'none';
  }

  // Añadir componente al contenedor
  addComponent(componente: string) {
    if (this.container) {
      // Crea y añade el nuevo componente
      switch (componente) {
        case 'Volumetria':
          this.container.createComponent(VolumetryComponent);
          break;
        case 'Map':
          this.container.createComponent(MapComponent);
          break;
        case 'Graph':
          this.container.createComponent(GraphComponent);
          break;
        case 'Spaghetti':
          this.container.createComponent(SpaghettiComponent);
          break;
        default:
          break;
      }
    }
  }
  
  // Método para dropdown
  isDropdownOpen = false;

  toggleDropdown() {
    const svg = document.getElementById("miSVG") as unknown as SVGElement;
    if (svg) {
      if(svg.style.visibility == "hidden"){
        svg.style.visibility = "visible"
      } else {svg.style.visibility = "hidden"}
    }
    this.isDropdownOpen = !this.isDropdownOpen;
   }
}