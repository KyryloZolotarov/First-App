import { Injectable } from '@angular/core';
import { Actions, ofType, createEffect } from '@ngrx/effects';
import { Store } from '@ngrx/store';
import { from, of } from 'rxjs';
import { catchError, map, mergeMap } from 'rxjs/operators';
import * as ListActions from '../actions/list-actions';
import axios from 'axios';
import { IList } from '../../interfaces/list';
import { IBoardLists } from '../../interfaces/boardLists';
import { IAddList } from '../../interfaces/addList';

@Injectable()
export class ListEffects {
  constructor(
    private actions$: Actions,
    private store: Store
  ) {}

  getLists$ = createEffect(() =>
    this.actions$.pipe(
      ofType(ListActions.getLists),
      mergeMap(action =>
        from(axios.get<IList[]>(`http://localhost:5007/lists/${action.boardId}`)).pipe(
          map(response => ListActions.getListsSuccess({ lists: response.data })),
          catchError(error => of(ListActions.getListsFailure({ error })))
        )
      )
    )
  );

  deleteList$ = createEffect(() =>
    this.actions$.pipe(
      ofType(ListActions.deleteList),
      mergeMap(action =>
        from(axios.delete(`http://localhost:5007/lists/${action.id}`, {data: {
          id:action.id,
          title:action.title,
          boardId:action.boardId
           }})).pipe(
          map(() => ListActions.getLists({boardId : action.boardId})),
          catchError(error => of(ListActions.deleteListFailure({ error })))
        )
      )
    )
  );
  addList$ = createEffect(() =>
    this.actions$.pipe(
      ofType(ListActions.addList),
      mergeMap(action =>
        from(axios.post<IAddList>(`http://localhost:5007/lists/`, {
          Title:action.title,
          BoardId:action.boardId
           })).pipe(
          map(() => ListActions.getLists({boardId : action.boardId})),
          catchError(error => of(ListActions.addListFailure({ error })))
        )
      )
    )
  );
}