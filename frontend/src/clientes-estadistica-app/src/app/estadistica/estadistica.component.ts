import { Component, ViewChildren, QueryList, ViewContainerRef, ElementRef, AfterViewInit, OnInit } from '@angular/core';
import { VolumetryComponent } from '../estadisticas/volumetry/volumetry.component'; // Asegúrate de importar el componente que deseas añadir

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

  addComponent(divNumber: number) {
    if (divNumber >= 1 && divNumber <= 4) {
      const container = this.containers[divNumber - 1];
      const element = this.elements[divNumber - 1];
      container.clear();  // Limpia los componentes dinámicos del contenedor
      // Limpia el contenido HTML estático
      element.nativeElement.innerHTML = '';
      container.createComponent(VolumetryComponent); // Crea y añade el nuevo componente
    }
  }
}
