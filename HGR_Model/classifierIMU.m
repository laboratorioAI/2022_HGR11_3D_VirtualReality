function [proccesingTime, gestoResultKNN] = classifierIMU(quat, datasetIMUs,kNNimu,thresholdkNNimu)

nameDynamicGestures={'relax';'up';'down';'left';'right';'forward';'backward'};
numMoves=7;
numTry=15;

%% Initializing variables

DTWUnknownGestureIMU=zeros(numTry*numMoves,4);

tClassification=tic;
%% ##############           DTW-EMG         ######################################################################################

parfor kDatasetIMU=1:sizeDatasetIMUs
    for kChannel=1:4
        DTWUnknownGestureIMU(kDatasetIMU,kChannel)=...
            dtw_c(datasetIMUs{kDatasetIMU,kChannel}, quat(:, kChannel), 50);
    end
end

%% ##############           KNN-EMG         #######################################################################################
DTWsumChannelIMU=sum(DTWUnknownGestureIMU,2);

[~,kNNresults]=sort(DTWsumChannelIMU);

kNNresults=ceil(kNNresults/numTry);

% Picking the closest k
kNNresults=kNNresults(1:kNNimu,:);

% % Finding the most common among the nearest neighbors
[gestoResultKNN,probGestureKNN]=mode(kNNresults);
%gestoResultKNN = me devuelve el valor que mas se repite
%probGestureKNN = me devuelve el numero de veces que gesTesultKNN se repite

% probability per unit
probGestureKNN=probGestureKNN/kNNimu;
% numero de reps del gestoResult / KNN

% Naming the resulting gesture
moveString=char(nameDynamicGestures{gestoResultKNN});


%% Umbral
if probGestureKNN>=thresholdkNNimu
    fprintf('%s,          %4.2f %%...\n', moveString , probGestureKNN*100);
    if gestoResultKNN~=1
        gestoResultKNN=gestoResultKNN+5;
    end
else
    fprintf('relax %4.2f %%...\n',probGestureKNN);
    gestoResultKNN=1;
end
proccesingTime = toc(tClassification);
end