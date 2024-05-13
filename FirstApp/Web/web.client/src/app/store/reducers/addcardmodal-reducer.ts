import { createReducer, on } from '@ngrx/store';
import { openAddCardModal, closeAddCardModal } from '../actions/app-actions';

export interface IAddCardModalState {
  isOpen: boolean;
}

const initialState: IAddCardModalState = {
  isOpen: false
};

export const addCardModalReducer = createReducer(
  initialState,
  on(openAddCardModal, state => ({ ...state, isOpen: true })),
  on(closeAddCardModal, state => ({ ...state, isOpen: false }))
);
