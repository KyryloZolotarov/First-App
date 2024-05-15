import { createReducer, on } from '@ngrx/store';
import * as ListActions from '../actions/list-actions';
import { IList } from '../../interfaces/list';
import { IAvailableList } from '../../interfaces/availableList';

export interface ListState {
  lists: IList[];
  availableListsForCards: IAvailableList[];
}

export const initialState: ListState = {
  lists: [],
  availableListsForCards: []
};

export const listReducer = createReducer(
  initialState,
  on(ListActions.addList, (state, { list }) => ({
    ...state,
    lists: [...state.lists, list]
  })),
  on(ListActions.deleteList, (state, { id }) => ({
    ...state,
    lists: state.lists.filter(list => list.id !== id)
  })),
  on(ListActions.getListsSuccess, (state, { lists }) => {debugger; return {
    ...state,
    lists: lists instanceof Array ? lists : [], // Убедимся, что lists является массивом
    availableListsForCards: lists instanceof Array ? 
      lists.map(list => ({ id: list.id, title: list.title })) : []
  }})
);

