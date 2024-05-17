import { createAction, props } from '@ngrx/store';
import { IList } from '../../interfaces/list';

export const addList = createAction('[List] Add List', props<{ title:string, boardId:number }>());
export const deleteList = createAction('[List] Delete List', props<{ id: number, title:string, boardId:number }>());
export const getLists = createAction('[List] Get Lists', props<{ boardId: number }>());
export const getListsSuccess= createAction('[List] Get Lists successfully', props<{lists:IList[]}>());
export const getListsFailure = createAction('[List] Get Lists Failure', props<{ error: any }>());
export const deleteListFailure = createAction('[List] Delete List Failure', props<{ error: any }>());
export const addListFailure = createAction('[List] Add List Failure', props<{ error: any }>());