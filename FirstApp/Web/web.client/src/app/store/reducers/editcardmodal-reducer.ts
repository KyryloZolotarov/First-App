import { createReducer, on } from '@ngrx/store';
import { openEditCardModal, closeEditCardModal } from '../actions/app-actions';

export interface IEditCardModalState {
  isOpen: boolean;
}

const initialState: IEditCardModalState = {
  isOpen: false
};

export const editCardModalReducer = createReducer(
  initialState,
  on(openEditCardModal, state => ({ ...state, isOpen: true })),
  on(closeEditCardModal, state => ({ ...state, isOpen: false }))
);