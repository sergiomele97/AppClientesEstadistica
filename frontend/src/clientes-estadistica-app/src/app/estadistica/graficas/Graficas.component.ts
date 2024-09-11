import {
  Component,
  ComponentFactoryResolver,
  ComponentRef,
  OnDestroy,
  OnInit,
  ViewChild,
  ViewContainerRef,
  Renderer2
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
  private subscription!: Subscription; // Suscripción para manejar el cierre de gráficos

  /**
   * Constructor del componente.
   * @param graficasServicio Servicio para gestionar gráficos.
   * @param componentFactoryResolver Resolvedor de fábricas de componentes.
   * @param renderer Renderer para manipulación del DOM.
   */
  constructor(
    private graficasServicio: GraficasService,
    private componentFactoryResolver: ComponentFactoryResolver,
    private renderer: Renderer2
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
  isComponentVisible(viewRef: ComponentRef<any>): boolean {
    const element = viewRef.location.nativeElement as HTMLElement;
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
      const closeButton = this.renderer.createElement('button');
      this.renderer.setProperty(closeButton, 'innerText', 'X');
      this.renderer.addClass(closeButton, 'absolute');
      this.renderer.addClass(closeButton, 'top-2');
      this.renderer.addClass(closeButton, 'right-2');
      this.renderer.addClass(closeButton, 'bg-red-500');
      this.renderer.addClass(closeButton, 'text-white');
      this.renderer.addClass(closeButton, 'rounded-full');
      this.renderer.addClass(closeButton, 'px-3');
      this.renderer.addClass(closeButton, 'py-1');
      this.renderer.listen(closeButton, 'click', () =>
        this.closeComponent(componentRef)
      );

      const element = componentRef.location.nativeElement;
      this.renderer.setStyle(element, 'position', 'relative'); // Asegurarse de que el botón de cierre esté posicionado correctamente
      this.renderer.appendChild(element, closeButton);
    }
  }

  /**
   * Cierra un componente y lo destruye.
   * @param componentRef Referencia al componente a cerrar.
   */
  closeComponent(componentRef: ComponentRef<any>) {
    componentRef.destroy();
  }

  public isDropdownOpen: boolean = false; // Controla la visibilidad del dropdown

  /**
   * Alterna la visibilidad del dropdown.
   */
  toggleDropdown() {
    const svg = document.getElementById('miSVG') as unknown as SVGElement | null;
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
