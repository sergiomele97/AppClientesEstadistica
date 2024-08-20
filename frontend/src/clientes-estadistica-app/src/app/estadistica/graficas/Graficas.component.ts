import {
  Component,
  ComponentFactoryResolver,
  ComponentRef,
  OnInit,
  ViewChild,
  ViewContainerRef,
} from '@angular/core';
import { Subscription } from 'rxjs';
import { GraphComponent } from 'src/app/estadisticas/graph/graph.component';
import { MapComponent } from 'src/app/estadisticas/map/map.component';
import { SpaghettiComponent } from 'src/app/estadisticas/spaghetti/spaghetti.component';
import { VolumetryComponent } from 'src/app/estadisticas/volumetry/volumetry.component';
import { GraficasService } from 'src/app/servicios/graficas.service';

@Component({
  selector: 'app-graficas',
  templateUrl: './Graficas.component.html',
  styleUrls: ['./Graficas.component.css'],
})
export class GraficasComponent implements OnInit {
  // Esto es para que escuche cuando se cierra una grafica
  private subscription: Subscription;

  constructor(private graficasServicio: GraficasService,
    private componentFactoryResolver: ComponentFactoryResolver
  ) {}

  ngOnInit() {
    this.subscription = this.graficasServicio.triggerScript$.subscribe(() => {
      this.onGraphClose();
    });
  }

  // Declarar contenedor
  @ViewChild('contenedor1', { read: ViewContainerRef })
  container!: ViewContainerRef;

  // Ejecutar cuando se cierra una grafica
  onGraphClose() {
    console.log('Hola');
  }

  isComponentVisible(viewRef: any): boolean {
    const element = viewRef.rootNodes[0] as HTMLElement;
    return element && window.getComputedStyle(element).display !== 'none';
  }

  // Método para añadir un componente al contenedor
  addComponent(componentName: string) {
    if (this.container) {
      let componentRef: ComponentRef<any>;
      switch (componentName) {
        case 'Volumetria':
          componentRef = this.container.createComponent(
            this.componentFactoryResolver.resolveComponentFactory(VolumetryComponent)
          );
          break;
        case 'Map':
          componentRef = this.container.createComponent(
            this.componentFactoryResolver.resolveComponentFactory(MapComponent)
          );
          break;
        case 'Graph':
          componentRef = this.container.createComponent(
            this.componentFactoryResolver.resolveComponentFactory(GraphComponent)
          );
          break;
        case 'Spaghetti':
          componentRef = this.container.createComponent(
            this.componentFactoryResolver.resolveComponentFactory(SpaghettiComponent)
          );
          break;
        default:
          return;
      }

      // Añadir botón de cerrar al componente
      const closeButton = document.createElement('button');
      closeButton.innerText = 'X';
      closeButton.className = 'absolute top-2 right-2 bg-red-500 text-white rounded-full px-3 py-1';
      closeButton.addEventListener('click', () => this.closeComponent(componentRef));

      const element = componentRef.location.nativeElement;
      element.style.position = 'relative'; // Para que el botón de cerrar esté posicionado correctamente
      element.appendChild(closeButton);
    }
  }

    // Método para cerrar un componente
    closeComponent(componentRef: ComponentRef<any>) {
      componentRef.destroy();
    }

  // Método para dropdown
  isDropdownOpen = false;

  toggleDropdown() {
    const svg = document.getElementById('miSVG') as unknown as SVGElement;
    if (svg) {
      if (svg.style.visibility == 'hidden') {
        svg.style.visibility = 'visible';
      } else {
        svg.style.visibility = 'hidden';
      }
    }
    this.isDropdownOpen = !this.isDropdownOpen;
  }
}
