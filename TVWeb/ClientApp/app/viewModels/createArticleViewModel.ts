import { Component } from '@angular/core';
import { imagemModel } from '../models/imagemModel';

export class CreateArticleViewModel {
    dataPublicacao: string;
    GitHubCodeURL: string;
    IdArtigo: number;
    QuantidadeViews: number;
    texto: string;
    titulo: string;
    imagem: imagemModel;
}
