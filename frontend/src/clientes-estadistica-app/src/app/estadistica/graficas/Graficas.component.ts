import { Component, ElementRef, OnInit, QueryList, ViewChildren, ViewContainerRef } from '@angular/core';
import { GraphComponent } from 'src/app/estadisticas/graph/graph.component';
import { MapComponent } from 'src/app/estadisticas/map/map.component';
import { SpaghettiComponent } from 'src/app/estadisticas/spaghetti/spaghetti.component';
import { VolumetryComponent } from 'src/app/estadisticas/volumetry/volumetry.component';

@Component({
  selector: 'app-graficas',
  templateUrl: './Graficas.component.html',
  styleUrls: ['./Graficas.component.css']
})
export class GraficasComponent implements OnInit {

  constructor() { }

  ngOnInit() {
  }

  // Declarar contenedores
  @ViewChildren('contenedor1', { read: ViewContainerRef }) containers1!: QueryList<ViewContainerRef>;
  @ViewChildren('contenedor2', { read: ViewContainerRef }) containers2!: QueryList<ViewContainerRef>;
  @ViewChildren('contenedor3', { read: ViewContainerRef }) containers3!: QueryList<ViewContainerRef>;
  @ViewChildren('contenedor4', { read: ViewContainerRef }) containers4!: QueryList<ViewContainerRef>;
  @ViewChildren('contenedor5', { read: ViewContainerRef }) containers5!: QueryList<ViewContainerRef>;
  @ViewChildren('contenedor6', { read: ViewContainerRef }) containers6!: QueryList<ViewContainerRef>;
  @ViewChildren('contenedor7', { read: ViewContainerRef }) containers7!: QueryList<ViewContainerRef>;
  @ViewChildren('contenedor8', { read: ViewContainerRef }) containers8!: QueryList<ViewContainerRef>;

  @ViewChildren('contenedor1', { read: ElementRef }) elements1!: QueryList<ElementRef>;
  @ViewChildren('contenedor2', { read: ElementRef }) elements2!: QueryList<ElementRef>;
  @ViewChildren('contenedor3', { read: ElementRef }) elements3!: QueryList<ElementRef>;
  @ViewChildren('contenedor4', { read: ElementRef }) elements4!: QueryList<ElementRef>;
  @ViewChildren('contenedor5', { read: ElementRef }) elements5!: QueryList<ElementRef>; 
  @ViewChildren('contenedor6', { read: ElementRef }) elements6!: QueryList<ElementRef>;
  @ViewChildren('contenedor7', { read: ElementRef }) elements7!: QueryList<ElementRef>;
  @ViewChildren('contenedor8', { read: ElementRef }) elements8!: QueryList<ElementRef>; 

  

  // Declarar las listas
  private containers: ViewContainerRef[] = [];
  private elements: ElementRef[] = [];
  private ContenedoresLibres: Boolean[] = [true,true,true,true,true,true,true,true];   // Si el contenedor esta libre es True

  // Inicializa la lista de contenedores y elementos después de que se haya renderizado el HTML
  ngAfterViewInit() {
    
    this.containers = [
      this.containers1.first,
      this.containers2.first,
      this.containers3.first,
      this.containers4.first,
      this.containers5.first,
      this.containers6.first,
      this.containers7.first,
      this.containers8.first
    ];
    
    this.elements = [
      this.elements1.first,
      this.elements2.first,
      this.elements3.first,
      this.elements4.first,
      this.elements5.first,
      this.elements6.first,
      this.elements7.first,
      this.elements8.first
    ];
  }

  // Añadir componente al contenedor
  addComponent(componente: string) {
    for (let i = 0; i < this.ContenedoresLibres.length; i++) {

      if (this.ContenedoresLibres[i]) {

        // Define contenedor y elemento
        const container = this.containers[i];
        const element = this.elements[i];

        // Boramos lo que había
        container.clear();  
        element.nativeElement.innerHTML = '';
        element.nativeElement.style.display = 'none'; // Oculta el div

        // Crea y añade el nuevo componente
        switch (componente) {
          case 'Volumetria':
            container.createComponent(VolumetryComponent);
            break
          case 'Map':
            container.createComponent(MapComponent);
            break
          case 'Graph':
            container.createComponent(GraphComponent);
            break
          case 'Spaghetti':
            container.createComponent(SpaghettiComponent);
            break
          default:
            break
        }

        this.ContenedoresLibres[i] = false
        return;
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
