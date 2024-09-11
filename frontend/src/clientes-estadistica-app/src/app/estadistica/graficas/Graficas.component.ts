// src/app/components/graficas/Graficas.component.ts

import {
  Component,
  ComponentFactoryResolver,
  ComponentRef,
  OnDestroy,
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

/**
 * Componente para la gestión y visualización de gráficos dinámicos.
 */
@Component({
  selector: 'app-graficas',
  templateUrl: './Graficas.component.html',
  styleUrls: ['./Graficas.component.css'],
})
export class GraficasComponent implements OnInit, OnDestroy {
  private subscription: Subscription; // Suscripción para manejar el cierre de gráficos

  /**
   * Constructor del componente.
   * @param graficasServicio Servicio para gestionar gráficos.
   * @param componentFactoryResolver Resolvedor de fábricas de componentes.
   */
  constructor(
    private graficasServicio: GraficasService,
    private componentFactoryResolver: ComponentFactoryResolver
  ) {}

  ngOnInit() {
    // Suscribirse al observable que maneja el cierre de gráficos
    this.subscription = this.graficasServicio.triggerScript$.subscribe(() => {
      this.onGraphClose();
    });
  }

  /**
   * ViewChild para el contenedor de componentes dinámicos.
   */
  @ViewChild('contenedor1', { read: ViewContainerRef })
  container!: ViewContainerRef;

  /**
   * Método llamado cuando se cierra un gráfico.
   */
  onGraphClose() {
    console.log('Hola');
  }

  /**
   * Verifica si un componente es visible.
   * @param viewRef Referencia a la vista del componente.
   * @returns `true` si el componente es visible, `false` en caso contrario.
   */
  isComponentVisible(viewRef: any): boolean {
    const element = viewRef.rootNodes[0] as HTMLElement;
    return element && window.getComputedStyle(element).display !== 'none';
  }

  /**
   * Agrega un componente al contenedor.
   * @param componentName Nombre del componente a agregar.
   */
  addComponent(componentName: string) {
    if (this.container) {
      let componentRef: ComponentRef<any>;
      switch (componentName) {
        case 'Volumetria':
          componentRef = this.container.createComponent(
            this.componentFactoryResolver.resolveComponentFactory(
              VolumetryComponent
            )
          );
          break;
        case 'Map':
          componentRef = this.container.createComponent(
            this.componentFactoryResolver.resolveComponentFactory(MapComponent)
          );
          break;
        case 'Graph':
          componentRef = this.container.createComponent(
            this.componentFactoryResolver.resolveComponentFactory(
              GraphComponent
            )
          );
          break;
        case 'Spaghetti':
          componentRef = this.container.createComponent(
            this.componentFactoryResolver.resolveComponentFactory(
              SpaghettiComponent
            )
          );
          break;
        default:
          return;
      }

      // Agregar un botón de cierre al componente
      const closeButton = document.createElement('button');
      closeButton.innerText = 'X';
      closeButton.className =
        'absolute top-2 right-2 bg-red-500 text-white rounded-full px-3 py-1';
      closeButton.addEventListener('click', () =>
        this.closeComponent(componentRef)
      );

      const element = componentRef.location.nativeElement;
      element.style.position = 'relative'; // Asegurarse de que el botón de cierre esté posicionado correctamente
      element.appendChild(closeButton);
    }
  }

  /**
   * Cierra un componente y lo destruye.
   * @param componentRef Referencia al componente a cerrar.
   */
  closeComponent(componentRef: ComponentRef<any>) {
    componentRef.destroy();
  }

  public isDropdownOpen = false; // Controla la visibilidad del dropdown

  /**
   * Alterna la visibilidad del dropdown.
   */
  toggleDropdown() {
    const svg = document.getElementById('miSVG') as unknown as SVGElement;
    if (svg) {
      svg.style.visibility =
        svg.style.visibility === 'hidden' ? 'visible' : 'hidden';
    }
    this.isDropdownOpen = !this.isDropdownOpen;
  }

  ngOnDestroy() {
    // Cancelar todas las suscripciones al destruir el componente
    if (this.subscription) {
      this.subscription.unsubscribe();
    }
  }
}
