import { Injectable } from '@angular/core';
import { Actions, ofType, createEffect } from '@ngrx/effects';
import { tap } from 'rxjs/operators';
import * as ModalActions from '../actions/app-actions';

@Injectable()
export class ModalEffects {
  constructor(private actions$: Actions) {}

  toggleAddCardModal$ = createEffect(() =>
    this.actions$.pipe(
      ofType(ModalActions.openAddCardModal, ModalActions.closeAddCardModal),
      tap(action => {
        // Логика для открытия и закрытия модального окна добавления карточки
      })
    ),
    { dispatch: false }
  );

  toggleEditCardModal$ = createEffect(() =>
    this.actions$.pipe(
      ofType(ModalActions.openEditCardModal, ModalActions.closeEditCardModal),
      tap(action => {
        // Логика для открытия и закрытия модального окна редактирования карточки
      })
    ),
    { dispatch: false }
  );
}