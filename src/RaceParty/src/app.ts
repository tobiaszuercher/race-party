import {Router, RouterConfiguration} from 'aurelia-router';

export class App {
  public router: Router;

  public configureRouter(config: RouterConfiguration, router: Router) {
    config.title = 'Race Party';
    config.map([
      { route: ['', 'welcome'], name: 'welcome',      moduleId: 'welcome',      nav: true, title: 'Welcome' },
      { route: 'users',         name: 'users',        moduleId: 'users',        nav: true, title: 'Github Users' },
      { route: 'child-router',  name: 'child-router', moduleId: 'child-router', nav: true, title: 'Child Router' },
      { route: 'drivers',       name: 'driver',       moduleId: 'driver',       nav: true, title: 'Drivers' },
      { route: 'laptimes',      name: 'contacts',     moduleId: 'laptimes',     nav: true, title: 'Laptimes' }
    ]);

    this.router = router;
  }
}
