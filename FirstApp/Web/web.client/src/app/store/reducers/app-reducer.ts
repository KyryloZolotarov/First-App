import { ActionReducerMap } from '@ngrx/store';
import { IEditCardModalState, editCardModalReducer } from './editcardmodal-reducer';
import { IAddCardModalState, addCardModalReducer } from './addcardmodal-reducer';

export interface AppState {
  editCardModal: IEditCardModalState;
  addCardModal: IAddCardModalState;
}

export const reducers: ActionReducerMap<AppState> = {
  editCardModal: editCardModalReducer,
  addCardModal: addCardModalReducer
};

