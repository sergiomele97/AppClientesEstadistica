import { Component, ViewChildren, QueryList, ViewContainerRef, ElementRef, AfterViewInit, OnInit } from '@angular/core';
import { VolumetryComponent } from '../estadisticas/volumetry/volumetry.component'; // Asegúrate de importar el componente que deseas añadir
import { GraphComponent } from '../estadisticas/graph/graph.component';

@Component({
  selector: 'app-estadistica',
  templateUrl: './estadistica.component.html',
  styleUrls: ['./estadistica.component.css']
})
export class EstadisticaComponent implements OnInit, AfterViewInit {
  @ViewChildren('contenedor1', { read: ViewContainerRef }) containers1!: QueryList<ViewContainerRef>;
  @ViewChildren('contenedor2', { read: ViewContainerRef }) containers2!: QueryList<ViewContainerRef>;
  @ViewChildren('contenedor3', { read: ViewContainerRef }) containers3!: QueryList<ViewContainerRef>;
  @ViewChildren('contenedor4', { read: ViewContainerRef }) containers4!: QueryList<ViewContainerRef>;

  @ViewChildren('contenedor1', { read: ElementRef }) elements1!: QueryList<ElementRef>;
  @ViewChildren('contenedor2', { read: ElementRef }) elements2!: QueryList<ElementRef>;
  @ViewChildren('contenedor3', { read: ElementRef }) elements3!: QueryList<ElementRef>;
  @ViewChildren('contenedor4', { read: ElementRef }) elements4!: QueryList<ElementRef>;

  private containers: ViewContainerRef[] = [];
  private elements: ElementRef[] = [];
  private ContenedoresLibres: Boolean[] = [true,true,true,true];   // Si el contenedor esta libre es True

  constructor() { }

  ngOnInit() { }

  ngAfterViewInit() {
    // Inicializa la lista de contenedores y elementos después de que se haya renderizado el HTML
    this.containers = [
      this.containers1.first,
      this.containers2.first,
      this.containers3.first,
      this.containers4.first
    ];
    
    this.elements = [
      this.elements1.first,
      this.elements2.first,
      this.elements3.first,
      this.elements4.first
    ];
  }

  // Añadir componente al contenedor
  addComponent() {
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
        container.createComponent(GraphComponent);

        this.ContenedoresLibres[i] = false
        return;
      }
    }
  }
}
