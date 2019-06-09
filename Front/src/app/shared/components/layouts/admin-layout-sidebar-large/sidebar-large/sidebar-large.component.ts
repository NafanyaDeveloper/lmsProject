import { Component, OnInit, HostListener } from '@angular/core';
import { NavigationService, IMenuItem, IChildItem } from '../../../../services/navigation.service';
import { Router, NavigationEnd } from '@angular/router';
import { filter } from 'rxjs/operators';
import { Utils } from '../../../../utils';
import { DirectionRepository } from 'src/app/model/repository/directionRepository';
import { DirectionToItemConverter } from 'src/app/model/converter/DirectionToItem.converter';
import { DirectionItem } from 'src/app/model/item/direction.item';

@Component({
  selector: 'app-sidebar-large',
  templateUrl: './sidebar-large.component.html',
  styleUrls: ['./sidebar-large.component.scss']
})
export class SidebarLargeComponent implements OnInit {

    selectedItem: IMenuItem;

	nav: IMenuItem[];

	loading: boolean = true;

	constructor(
		public router: Router,
		public navService: NavigationService,
		private repoD: DirectionRepository,
		private converter: DirectionToItemConverter
	) { }

	ngOnInit() {
		this.updateSidebar();
		// CLOSE SIDENAV ON ROUTE CHANGE
		this.router.events.pipe(filter(event => event instanceof NavigationEnd))
			.subscribe((routeChange) => {
				this.closeChildNav();
				if (Utils.isMobile()) {
					this.navService.sidebarState.sidenavOpen = false;
				}
			});

		this.repoD.getDirections()
			.subscribe((items) => {
				this.nav = this.converter.ConvertArray(items);
				this.nav.unshift({
					name: 'Calendar',
					description: 'Calendar',
					type: 'link',
					icon: 'i-Calendar',
					state: '/calendar'
				});
				this.setActiveFlag();
				this.loading = false;
			});
	}

	selectItem(item) {
		this.navService.sidebarState.childnavOpen = true;
		this.selectedItem = item;
		this.setActiveMainItem(item);
	}
	closeChildNav() {
		this.navService.sidebarState.childnavOpen = false;
		this.setActiveFlag();
	}

	onClickChangeActiveFlag(item) {
		this.setActiveMainItem(item);
	}
	setActiveMainItem(item) {
		this.nav.forEach(item => {
			item.active = false;
		});
		item.active = true;
	}

	setActiveFlag() {
		if (window && window.location) {
            const activeRoute = window.location.hash || window.location.pathname;
			this.nav.forEach(item => {
				item.active = false;
				if (activeRoute.indexOf(item.state) !== -1) {
                    this.selectedItem = item;
					item.active = true;
				}
				if (item.sub) {
					item.sub.forEach(subItem => {
                        subItem.active = false;
						if (activeRoute.indexOf(subItem.state) !== -1) {
                            this.selectedItem = item;
                            item.active = true;
                        }
                        if (subItem.sub) {
                            subItem.sub.forEach(subChildItem => {
                                if (activeRoute.indexOf(subChildItem.state) !== -1) {
                                    this.selectedItem = item;
                                    item.active = true;
                                    subItem.active = true;
                                }
                            });
                        }
					});
				}
            });
		}
    }

	updateSidebar() {
		if (Utils.isMobile()) {
			this.navService.sidebarState.sidenavOpen = false;
			this.navService.sidebarState.childnavOpen = false;
		} else {
			this.navService.sidebarState.sidenavOpen = true;
		}
	}

	@HostListener('window:resize', ['$event'])
	onResize(event) {
		this.updateSidebar();
    }

}
