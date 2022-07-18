import {Injectable} from '@angular/core';
import {ActivatedRouteSnapshot, CanActivate, Router, RouterStateSnapshot, UrlTree} from '@angular/router';
import {Observable} from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class AuthGuard implements CanActivate {
  constructor(private router: Router) {
  }

  canActivate(
    route: ActivatedRouteSnapshot,
    state: RouterStateSnapshot): Observable<boolean | UrlTree> | Promise<boolean | UrlTree> | boolean | UrlTree {
    // const isLoggedIn = localStorage.getItem('user-details');
    return true;
    // if (isLoggedIn) {
    //   return true;
    // }
    // this.router.navigate(['/login'], {queryParams: {returnUrl: state.url}});
    // return false;
  }
}
