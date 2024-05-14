import { combineReducers } from '@ngrx/store';
import { listReducer } from './list-reducer';
import { RootState } from '../interfaces/root-state';

export const rootReducer = combineReducers<RootState>({
  list: listReducer,
});