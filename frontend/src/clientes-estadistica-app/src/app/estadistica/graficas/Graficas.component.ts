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

@Component({
  selector: 'app-graficas',
  templateUrl: './Graficas.component.html',
  styleUrls: ['./Graficas.component.css'],
})
export class GraficasComponent implements OnInit, OnDestroy {
  // Subscription for handling when a graph is closed
  private subscription: Subscription;

  constructor(
    private graficasServicio: GraficasService,
    private componentFactoryResolver: ComponentFactoryResolver
  ) {}

  ngOnInit() {
    this.subscription = this.graficasServicio.triggerScript$.subscribe(() => {
      this.onGraphClose();
    });
  }

  // ViewChild for dynamic component container
  @ViewChild('contenedor1', { read: ViewContainerRef })
  container!: ViewContainerRef;

  // Method called when a graph is closed
  onGraphClose() {
    console.log('Hola');
  }

  // Check if a component is visible
  isComponentVisible(viewRef: any): boolean {
    const element = viewRef.rootNodes[0] as HTMLElement;
    return element && window.getComputedStyle(element).display !== 'none';
  }

  // Add a component to the container
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

      // Add close button to the component
      const closeButton = document.createElement('button');
      closeButton.innerText = 'X';
      closeButton.className =
        'absolute top-2 right-2 bg-red-500 text-white rounded-full px-3 py-1';
      closeButton.addEventListener('click', () =>
        this.closeComponent(componentRef)
      );

      const element = componentRef.location.nativeElement;
      element.style.position = 'relative'; // Ensure close button is positioned correctly
      element.appendChild(closeButton);
    }
  }

  // Close a component
  closeComponent(componentRef: ComponentRef<any>) {
    componentRef.destroy();
  }

  // Dropdown toggle
  isDropdownOpen = false;

  toggleDropdown() {
    const svg = document.getElementById('miSVG') as unknown as SVGElement;
    if (svg) {
      svg.style.visibility =
        svg.style.visibility === 'hidden' ? 'visible' : 'hidden';
    }
    this.isDropdownOpen = !this.isDropdownOpen;
  }

  // Cleanup on component destruction
  ngOnDestroy() {
    // Unsubscribe from any active subscriptions
    if (this.subscription) {
      this.subscription.unsubscribe();
    }
  }
}
