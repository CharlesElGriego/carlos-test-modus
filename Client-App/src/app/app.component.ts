import { MediaMatcher } from '@angular/cdk/layout';
import { ChangeDetectionStrategy, ChangeDetectorRef, Component, OnDestroy, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Observable } from 'rxjs';
import { takeWhile } from 'rxjs/operators';
import { AuthService } from './security/auth.service';
import { ErrorHandlerService } from './security/error-handler.service';
import { User } from './security/models';
import { SnackbarService } from './shared/services/snackbar.service';
@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss'],
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class AppComponent implements OnInit, OnDestroy {

  //#region   Public Properties
  mobileQuery: MediaQueryList;
  navList = [
    {
      link: 'feeds',
      name: 'Feeds',
      exact: true,
    },
    {
      link: 'my-feeds',
      name: 'My Feeds',
      exact: true,
    },
    {
      link: 'feeds',
      name: 'My News',
      exact: true,
    },
  ];
  title = 'Carlos News Feeds';
  //#endregion

  //#region   Observables
  authenticated$: Observable<boolean>;
  user$: Observable<User>;
  //#endregion

  //#region   Private Properties
  private alive = true;
  private mobileQueryListener: () => void;
  //#endregion

  //#region   Constructor
  constructor(
    private authService: AuthService,
    private changeDetectorRef: ChangeDetectorRef,
    private errorHandlerService: ErrorHandlerService,
    private router: Router,
    private snackbarService: SnackbarService,
    private media: MediaMatcher) {
    this.mobileQuery = media.matchMedia('(max-width: 600px)');
    this.mobileQueryListener = () => changeDetectorRef.detectChanges();
    this.mobileQuery.addListener(this.mobileQueryListener);
  }
  //#endregion

  //#region   Life Cycle Hooks
  ngOnInit(): void {
    this.registerEvents();
  }
  ngOnDestroy(): void {
    this.alive = false;
  }
  //#endregion

  //#region   Public Methods
  logOut(): void {
    this.authService.logOut();
    this.router.navigate(['login']);
  }
  //#endregion

  //#region   Private Methods
  private registerEvents(): void {
    if (this.authService.isAlreadyAuthenticated()) {
      this.router.navigate(['feeds']);
    } else {
      this.router.navigate(['login']);
    }
    this.authenticated$ = this.authService.authenticated$;
    this.user$ = this.authService.user$;

    this.errorHandlerService.serverError$
      .pipe(takeWhile(() => this.alive))
      .subscribe(message => {
        if (message) {
          this.snackbarService.showError(message);
        }
      });
  }
}
